using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject[] drop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the tree's health is less than or equal to 0
        if (GetComponent<Health>().hp <= 0)
        {
            //for each slot in the drop array
            for (int i = 0; i < drop.Length; i++)
            {
                //spawn the item that is to be dropped according to the currently selected slot
                Instantiate(drop[i], transform.position, drop[i].transform.rotation);
            }
            //destroy the tree
            Destroy(gameObject);
        }
    }
}
