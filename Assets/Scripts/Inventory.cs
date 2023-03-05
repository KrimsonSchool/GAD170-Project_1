using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Inventory : MonoBehaviour
{
    public int[] slots;
    public string[] itemNames;
    string all;

    // Update is called once per frame
    void Update()
    {
        //call the variable 'update text' every frame
        UpdateText();
    }

    //the function update text
    void UpdateText()
    {
        //set the text to blank
        all = "";
        //for every slot in the player inventory
        for (int i = 0; i < slots.Length; i++)
        {
            //the text equal the past piece of text plus the current item in the selected slot
            all += itemNames[slots[i]].ToString() + " in slot " + (i + 1) + ", ";
        }
        //set the physical text to be the ser text variable
        FindObjectOfType<TMPro.TextMeshPro>().text = all;
    }
}
