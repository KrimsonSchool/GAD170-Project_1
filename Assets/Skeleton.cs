using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public int ATTACK;
    float attacktimer;
    public GameObject HealthIndicator;
    int hpcheck;
    float checktimer;
    // Start is called before the first frame update
    void Start()
    {
        hpcheck = GetComponent<Health>().Hp;
    }

    // Update is called once per frame
    void Update()
    {
        int damping = 2;
        Transform target = FindObjectOfType<Character>().gameObject.transform;

        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        if (Vector3.Distance(target.position, transform.position) > 1)
        {
            attacktimer = 0;
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);

            GetComponent<Animator>().SetBool("Attack", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Attack", true);

            attacktimer += Time.deltaTime;
        }

        //print("DISTANCE = " + Vector3.Distance(target.position, transform.position));


        if (GetComponent<Health>().Hp <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<LevelingSystem>().Xp += Mathf.RoundToInt(5 * (FindObjectOfType<StatsSystem>().Luck * 0.25f));
        }

        if (attacktimer >= 1)
        {

            attacktimer = 0;

            int layerMask = 1 << 8;
            layerMask = ~layerMask;

            RaycastHit hit;
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit at " + hit.distance);

                if (hit.collider.gameObject.GetComponent<Character>() != null)
                {
                    if (hit.distance <= 1)
                    {
                        hit.collider.gameObject.GetComponent<Character>().Hp -= ATTACK;
                    }
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.white);
            }

           
        }

        if (hpcheck != GetComponent<Health>().Hp)
        {
            HealthIndicator.SetActive(true);
            checktimer += Time.deltaTime;
        }

        if (checktimer >= 0.3)
        {
            checktimer = 0;
            hpcheck = GetComponent<Health>().Hp;
            HealthIndicator.SetActive(false);
        }
    }
}

