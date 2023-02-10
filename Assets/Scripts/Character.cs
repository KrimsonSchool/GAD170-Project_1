using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector] public GameObject Cam;
    bool CanJump;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Input.GetAxis("Vertical") * 10 * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal") * 10 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            CanJump = false;
            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 250);
        }

        //Cam.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
        Cam.transform.RotateAround(gameObject.transform.position, transform.right, -Input.GetAxis("Mouse Y"));

        gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * 6, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn")
        {
            CanJump = true;
        }
    }

}
