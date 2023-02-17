using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Activity : MonoBehaviour
{
    string FavGame;
    int Hours;
    float Price;
    // Start is called before the first frame update
    void Start()
    {
        FavGame = "Death Stranding";
        Price = 80;
        Hours = 67;
        Debug.Log("My Favourite game is " + FavGame + ", and i have played it for " + Hours + " hours, it cost me $" + Price + ", therfore my value of dollar per hour is $" + (Hours / Price) + " / hour");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
