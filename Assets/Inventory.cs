using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Inventory : MonoBehaviour
{
    public int[] Slots;
    public string[] ItemNames;
    string all;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        all = "";
        for (int i = 0; i < Slots.Length; i++)
        {
            all += ItemNames[Slots[i]].ToString() + " in slot " + (i + 1) + ", ";
        }
        FindObjectOfType<TMPro.TextMeshPro>().text = all;
    }
}
