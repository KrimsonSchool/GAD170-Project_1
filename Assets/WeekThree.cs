using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class WeekThree : MonoBehaviour
{
    int strength, agility, intelligence, Power;
    int strength2, agility2, intelligence2, Power2;
    // Start is called before the first frame update
    void Start()
    {
        strength = Random.Range(0, 11);
        agility = Random.Range(0, 11);
        intelligence = Random.Range(0, 11);
        strength2 = Random.Range(0, 11);
        agility2 = Random.Range(0, 11);
        intelligence2 = Random.Range(0, 11);

        Power = Mathf.RoundToInt((strength * 2) + (agility * 1.5f) + intelligence);
        Power2 = Mathf.RoundToInt((strength2 * 2) + (agility2 * 1.5f) + intelligence2);

        print(Power);
        if(Power2 == Power)
        {
            print("The 2 champions are equally matched!");
        }
        else if(Power2 > Power)
        {
            print("Player 2 is more powerful!");
        }
        else
        {
            print("Player 1 is more powerful!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
