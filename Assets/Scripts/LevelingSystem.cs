using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelingSystem : MonoBehaviour
{
    [HideInInspector] public int level;
     public int xp;
     public int xpTo;
    public TMPro.TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        //set xp goal
        xpTo = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //set the text for level and xp amount / goal
        levelText.text = "level = " + level + ", xp = " + xp + " / " + xpTo;
        
        //if xp is equal to xp goal
        if (xp >= xpTo)
        {
            //xp is minused by the goal
            xp -= xpTo;
            //goal is set as 1.1 times its current value
            xpTo = Mathf.RoundToInt(xpTo * 1.1f);
            //level is increased by 1
            level += 1;
            //4 points are given for distrobution
            FindObjectOfType<StatsSystem>().assignPoints += 4;
            //the points are randomly assigned through the Assign function in the StatsSystem script
            FindObjectOfType<StatsSystem>().Assign();
        }
    }
}
