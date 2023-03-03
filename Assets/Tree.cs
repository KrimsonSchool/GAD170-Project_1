using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject[] Drop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Health>().Hp<= 0)
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
            GetComponent<Health>().Hp -= FindObjectOfType<Character>().Attack;
        }
    }
}
