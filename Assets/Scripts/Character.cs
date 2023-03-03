using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    [HideInInspector] public GameObject Cam;
    bool CanJump;
    public float Speed;
    public int Attack;
    GameObject otr;
    int i;
    public int Hp;
    public int MaxHp;
    public TMPro.TextMeshProUGUI HpText;
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
        transform.position += transform.forward * Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

        if(Input.GetAxis("Vertical")!=0 || Input.GetAxis("Horizontal") != 0)
        {
            GetComponent<Animator>().SetBool("Walking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            GetComponent<Animator>().SetBool("Jump", true);
            CanJump = false;
            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 250);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetBool("Attack", true);

            int layerMask = 1 << 8;
            layerMask = ~layerMask;

            RaycastHit hit;
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y+1, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit at " + hit.distance);

                if(hit.collider.gameObject.tag == "target")
                {
                    if(hit.distance <= 1)
                    {
                        hit.collider.gameObject.GetComponent<Health>().Hp -= Attack;
                    }
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.white);
            }
        }

        //Cam.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
        Cam.transform.RotateAround(gameObject.transform.position, transform.right, -Input.GetAxis("Mouse Y"));  

        gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * 6, 0);

        if (CanJump)
        {
            GetComponent<Animator>().SetBool("Jump", false);
        }

        Attack = Mathf.RoundToInt(FindObjectOfType<StatsSystem>().Strength * 0.4f + FindObjectOfType<StatsSystem>().Intelligence * 0.2f * FindObjectOfType<LevelingSystem>().Level * 0.1f) + 1;

        HpText.text = "HP : " + Hp;

        MaxHp = 10 + Mathf.RoundToInt(GetComponent<StatsSystem>().Endurance * 0.8f);
    }

    void Pickup()
    {
        if (GetComponent<Inventory>().Slots[i] != 0)
        {
            i++;
            Pickup();
        }
        else
        {
            GetComponent<Inventory>().Slots[i] = otr.GetComponent<Resource>().ID;
            Destroy(otr);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn")
        {
            
        }

        if (other.tag == "Pickup")
        {
            otr = other.gameObject;
            Pickup();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        CanJump = true;
    }

    public void AttackDone()
    {
        GetComponent<Animator>().SetBool("Attack", false);
    }
    
}
