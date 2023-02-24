using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public int Health;
    public GameObject[] Drop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health<= 0)
        {
            for (int i = 0; i < Drop.Length; i++)
            {
                Instantiate(Drop[i], transform.position, Drop[i].transform.rotation);
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Attack")
        {
            Health -= FindObjectOfType<Character>().Attack;
        }
    }
}
