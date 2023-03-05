using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSystem : MonoBehaviour
{
    [HideInInspector] public int intelligence;
    [HideInInspector] public int agility;
    [HideInInspector] public int strength;
    [HideInInspector] public int luck;
    [HideInInspector] public int endurance;
    public int assignPoints;
    public int allAdded;
    //stat
    //battle
    //level
    // Start is called before the first frame update
    void Start()
    {
        //set amount of points to assign
        assignPoints = 20;
        //call assign function
        Assign();
    }

    // Update is called once per frame
    void Update()
    {
        //a debug value of the total value of all stats to make sure the points have been distributed properly
        allAdded = intelligence + agility + strength + luck + endurance;
    }
    //the function for assigning points
    public void Assign()
    {
        //while there are points left to assign
        while (assignPoints>0)
        {
            //randomly pick 1 of the 5 stats to put a point into
            int set = Random.Range(0, 5);

            //each of the 5 values is designated a stat
            if (set == 0)
            {
                //incrase the stats value by 1
                intelligence += 1;
            }
            else if (set == 1)
            {
                //incrase the stats value by 1
                agility += 1;
            }
            else if (set == 2)
            {
                //incrase the stats value by 1
                strength += 1;
            }
            else if (set == 3)
            {
                //incrase the stats value by 1
                luck += 1;
            }
            else if (set == 4)
            {
                //incrase the stats value by 1
                endurance += 1;
            }
            //after each round of stat allocation reduce the amount of assignable points available
            assignPoints -= 1;
        }
        
        //debug print the vaule of each stat
        //print("Int = " + intelligence + " Agil = " + agility + " Str = " + strength + " luck = " + luck + " End = " + endurance);
        //debug print the amount of poimts left (if the script is working properly and assigning all points this value should output 0)
        //print("Points Left = " + assignPoints);
        //set the players max hp as a value of endurance
        GetComponent<Character>().maxHp = 10 + Mathf.RoundToInt(endurance * 0.8f);
        //set the players hp to its max hp
        GetComponent<Character>().hp = GetComponent<Character>().maxHp;
    }
}
