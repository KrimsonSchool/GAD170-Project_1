using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSystem : MonoBehaviour
{
    [HideInInspector] public int Intelligence;
    [HideInInspector] public int Agility;
    [HideInInspector] public int Strength;
    [HideInInspector] public int Luck;
    [HideInInspector] public int Endurance;
    public int AssignPoints;
    public int ALLADDED;
    //stat
    //battle
    //level
    // Start is called before the first frame update
    void Start()
    {
        AssignPoints = 20;
        Assign();
    }

    // Update is called once per frame
    void Update()
    {
        ALLADDED = Intelligence + Agility + Strength + Luck + Endurance;
    }
    public void Assign()
    {
        while (AssignPoints>0)
        {
            int set = Random.Range(0, 5);

            if (set == 0)
            {
                Intelligence += 1;
            }
            else if (set == 1)
            {
                Agility += 1;
            }
            else if (set == 2)
            {
                Strength += 1;
            }
            else if (set == 3)
            {
                Luck += 1;
            }
            else if (set == 4)
            {
                Endurance += 1;
            }
            AssignPoints -= 1;
        }
        

        print("Int = " + Intelligence + " Agil = " + Agility + " Str = " + Strength + " Luck = " + Luck + " End = " + Endurance);
        print("Points Left = " + AssignPoints);
    }
}
