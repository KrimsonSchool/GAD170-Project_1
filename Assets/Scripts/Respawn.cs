using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    float timer;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 2)
        {
            
            timer = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn")
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            transform.position = pos;
        }
    }
}
