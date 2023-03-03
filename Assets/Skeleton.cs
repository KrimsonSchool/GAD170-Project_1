using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public int ATTACK;

    // Start is called before the first frame update
    void Start()
    {

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
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);

            GetComponent<Animator>().SetBool("Attack", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Attack", true);
        }

        //print("DISTANCE = " + Vector3.Distance(target.position, transform.position));


        if (GetComponent<Health>().Hp <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<LevelingSystem>().Xp += Mathf.RoundToInt(5 * (FindObjectOfType<StatsSystem>().Luck * 0.25f));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Attack")
        {
            GetComponent<Health>().Hp -= FindObjectOfType<Character>().Attack;
        }
    }
}

