using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public int attack;
    float attackTimer;
    public GameObject healthIndicator;
    int hpCheck;
    float checkTimer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //sets the test variable 'hp check' to the skeletons current health
        hpCheck = GetComponent<Health>().hp;
    }

    // Update is called once per frame
    void Update()
    {
        //sets the player as the skeleton's target
        int damping = 2;
        Transform target = FindObjectOfType<Character>().gameObject.transform;

        //makes the skeleton always face the player
        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        //if the distance to the player is greater than 1
        if (Vector3.Distance(target.position, transform.position) > 1)
        {
            //makes the skeleton move towards the player according to its speed variable
            attackTimer = 0;
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

            GetComponent<Animator>().SetBool("attack", false);
        }
        //if the distance to the player is less than 1
        else
        {
            //set the animation to attack
            GetComponent<Animator>().SetBool("attack", true);
            //make the timer count up in seconds
            attackTimer += Time.deltaTime;
        }

        //print("DISTANCE = " + Vector3.Distance(target.position, transform.position));

        //if the skeleton's health is less than or equal to 1
        if (GetComponent<Health>().hp <= 0)
        {
            //give the player xp according to the players luck stat
            FindObjectOfType<LevelingSystem>().xp += Mathf.RoundToInt(5 * (FindObjectOfType<StatsSystem>().luck * 0.25f));
            //destroy the skeleton
            Destroy(gameObject);
        }

        //if the attack timer is greater than 1
        if (attackTimer >= 1)
        {
            //reduce the players health according to the skeletons attack stat
            FindObjectOfType<Character>().hp -= attack;
            //reset the attack timer's value
            attackTimer = 0;
        }

        //if there is a discrepency between the hp check variable and the health of the skeleton then the skeleton must have taken damage
        if (hpCheck != GetComponent<Health>().hp)
        {
            //make the skeleton flash red
            healthIndicator.SetActive(true);
            //increase the check timer by seconds
            checkTimer += Time.deltaTime;
        }

        //if the check timer is greater or equal to 0.3
        if (checkTimer >= 0.3)
        {
            //set the hp check variable to the skeleton's current health
            hpCheck = GetComponent<Health>().hp;
            //make the skeleton no longer red
            healthIndicator.SetActive(false);
            //the check timer equals 0
            checkTimer = 0;
        }
    }
}

