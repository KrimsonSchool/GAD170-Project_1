using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static UnityEditor.PlayerSettings;

public class Week2Activity : MonoBehaviour
{
    string favGame;
    int hours;
    float price;
    // Start is called before the first frame update
    void Start()
    {
        favGame = "Death Stranding";
        price = 80;
        hours = 67;
        print("My Favourite game is " + favGame + ", and i have played it for " + hours + " hours, it cost me $" + price + ", therfore my value of dollar per hour is $" + (hours / price) + " / hour");

        float rng = Random.Range(1, 11);

        if(rng == 1)
        {
            print("The number was exactly one");
        }
        else if(rng > 3)
        {
            print("The number was greater than three");
        }

        if(rng < 3 || rng > 5)
        {
            print("The number was less than three or greater than 5");
        }
        else
        {
            print("The number is 4");
        }

        if(rng > 1 && rng < 5 || rng > 5)
        {
            print("the number was greater than one and less than 5; or the number was greater than 5");
        }
        Debug.Log("My Favourite game is " + favGame + ", and i have played it for " + hours + " hours, it cost me $" + price + ", therfore my value of dollar per hour is $" + (hours / price) + " / hour");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
