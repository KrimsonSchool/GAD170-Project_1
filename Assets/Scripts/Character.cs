using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    [HideInInspector] public GameObject Cam;
    bool canJump;
    public float speed;
    public int attack;
    GameObject otr;
    int i;
    public int hp;
    public int maxHp;
    public TMPro.TextMeshProUGUI hpText;
    float jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Cam = Camera.main.gameObject;

        jumpHeight = 250;
    }

    // Update is called once per frame
    void Update()
    {
        //when the player presses the input keys (WASD or ARROW KEYS) then the player will move according to the characters direction and the players speed value
        transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        //if the players vertical or horizontal movement values arent 0 (either of them)
        if(Input.GetAxis("Vertical")!=0 || Input.GetAxis("Horizontal") != 0)
        {
            //the character plays the 'walking' animation
            GetComponent<Animator>().SetBool("Walking", true);
        }
        //if not (so the player is completly stationary)
        else
        {
            //the character plays the idle animation
            GetComponent<Animator>().SetBool("Walking", false);
        }

        //if the player presses the jump key
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            //the jump animation plays
            GetComponent<Animator>().SetBool("Jump", true);
            //the character is set so that it cant jump again
            canJump = false;
            //the player is pushed upwards according to the 'jump height' value
            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpHeight);
        }

        //when the player clicks the mouse a ray is shot from the player, if it hits anything then that object takes damage (if they possess the 'Health' script)
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetBool("attack", true);

            int layerMask = 1 << 8;
            layerMask = ~layerMask;

            RaycastHit hit;
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y+1, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit at " + hit.distance);

                //if the players ray hits something
                if(hit.collider.gameObject.tag == "target")
                {
                    //if the distance to the hit object is 1 or less away
                    if(hit.distance <= 1)
                    {
                        //the object takes damage according to the players 'attack' value
                        hit.collider.gameObject.GetComponent<Health>().hp -= attack;
                    }
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.white);
            }
        }

        //the players camera rotates around accoridng to the players mouse position in the Y quadrant
        //Cam.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
        Cam.transform.RotateAround(gameObject.transform.position, transform.right, -Input.GetAxis("Mouse Y"));

        //the character rotates around accoridng to the players mouse position in the X quadrant
        gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * 6, 0);

        //if the player is able to jump
        if (canJump)
        {
            //the character plays the idle animation
            GetComponent<Animator>().SetBool("Jump", false);
        }

        //the attack stat is set according to the players strength, intelligence and level stats 
        attack = Mathf.RoundToInt(FindObjectOfType<StatsSystem>().strength * 0.4f + FindObjectOfType<StatsSystem>().intelligence * 0.2f * FindObjectOfType<LevelingSystem>().level * 0.1f) + 1;

        //the hp text is equal to the player hp stat
        hpText.text = "hp : " + hp;

        //the players max hp is allocated according to the players endureance stat
        maxHp = 10 + Mathf.RoundToInt(GetComponent<StatsSystem>().endurance * 0.8f);

        //the players speed and jump heigh is allocated accoridng to the player agility stat
        speed = 1 + GetComponent<StatsSystem>().agility * 0.1f;
        jumpHeight = 250 + GetComponent<StatsSystem>().agility * 10;
    }

    //the function for picking up item
    void Pickup()
    {
        //if the selected slot is full
        if (GetComponent<Inventory>().slots[i] != 0)
        {
            //select the next slot and call the pickup function
            i++;
            Pickup();
        }
        //else
        else
        {
            //fill the selected slot with the item being picked up and destroy the physical object
            GetComponent<Inventory>().slots[i] = otr.GetComponent<Resource>().id;
            Destroy(otr);
        }
    }

    //if the player collides with a trigger
    private void OnTriggerEnter(Collider other)
    {
        //if the object collided has the pickup tag
        if (other.tag == "Pickup")
        {
            //assign the object to a variable and call the pickup function
            otr = other.gameObject;
            Pickup();
        }
    }

    //if the player collides with something
    private void OnCollisionEnter(Collision collision)
    {
        //set it so the player can jump
        canJump = true;
    }

    //if the players attack animation is done
    public void attackDone()
    {
        //set the players animation to idle
        GetComponent<Animator>().SetBool("attack", false);
    }
    
}
