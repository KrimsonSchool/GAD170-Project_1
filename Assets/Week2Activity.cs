using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static UnityEditor.PlayerSettings;
=======
using UnityEngine;
>>>>>>> 6d7f1e9c614d19a58d56afffbbb605c62e18f9df

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
<<<<<<< HEAD
        print("My Favourite game is " + FavGame + ", and i have played it for " + Hours + " hours, it cost me $" + Price + ", therfore my value of dollar per hour is $" + (Hours / Price) + " / hour");

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
=======
        Debug.Log("My Favourite game is " + FavGame + ", and i have played it for " + Hours + " hours, it cost me $" + Price + ", therfore my value of dollar per hour is $" + (Hours / Price) + " / hour");
>>>>>>> 6d7f1e9c614d19a58d56afffbbb605c62e18f9df
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
