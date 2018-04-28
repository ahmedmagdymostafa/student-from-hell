//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour {

    public bool isGrounded;
    private float speed;
    public float rotSpeed;
    public float jumpHeight;
    private float w_speed = 0.02f;
    private float rot_speed = 3.0f;
    private bool crouching=false;
    private bool crouchwalk = false;
    public GameObject flasha;
    public GameObject mp3;
    public GameObject mosmar;
    public GameObject mp3_3d;
    public GameObject m2as;
    public GameObject flasha_3d;
    public GameObject mosmar_3d;
    public GameObject m2as_3d;
    Rigidbody rp;
    Animator anim;

    void movementControl(string state)
    {
        switch (state)
        {
            case "WalkingForward":

                anim.SetBool("isWalkingForward", true);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("Stand", false);
                break;
            case "WalkingBackward":
                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", true);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("Stand", false);
                break;
            case "Idle":

                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isCrouch", false);
                break;

            case "Running":

                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", true);

                break;
            case "crouch":
                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isCrouch", true);
                anim.SetBool("crouchWalk", false);
                break;
            case "walkingCrouch":
                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isCrouch", false);
                anim.SetBool("crouchWalk", true);
                break;

        }
    }

    // Use this for initialization
    void Start()
    {
        rp = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isGrounded = true;
        GameObject go = GameObject.Find("wibble");
        //Debug.Log(go.name);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(mp3_3d.transform.position, this.transform.position) < 0.5f)
        {
            if (mp3_3d.active)
            {
                mp3_3d.SetActive(false);
                mp3.SetActive(true);
                scoresc.scoreValue += 1;
                
            }

        }
        if (Vector3.Distance(mosmar_3d.transform.position, this.transform.position) < 0.5f)
        {
            if (mosmar_3d.active)
            {
                mosmar_3d.SetActive(false);
                mosmar.SetActive(true);
                scoresc.scoreValue += 1;
            }

        }
        if (Vector3.Distance(flasha_3d.transform.position, this.transform.position) < 0.5f)
        {
            if (flasha_3d.active)
            {
                flasha_3d.SetActive(false);
                flasha.SetActive(true);
                scoresc.scoreValue += 1;
            }
        }
        if (Vector3.Distance(m2as_3d.transform.position, this.transform.position) < 0.5f)
        {
            if (m2as_3d.active)
            {
                m2as_3d.SetActive(false);
                m2as.SetActive(true);
                scoresc.scoreValue += 1;
            }
        }
        if (isGrounded)
        {   //moving forward and backward
            if (scoresc.scoreValue == 104)
            {
                FindObjectOfType<GameManagerscene2>().endgame();
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey("up"))
            {
                speed = w_speed;
                if (!crouching) {
                    movementControl("WalkingForward");
                }
                else
                {
                    movementControl("walkingCrouch");
                    crouchwalk = true;
                }
                

            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey("down"))
            {
                speed = w_speed;
                if(!crouching)
                    movementControl("WalkingBackward");
                else
                {
                    movementControl("walkingCrouch");
                    crouchwalk = true;
                }
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = w_speed;
                movementControl("Running");
                this.transform.Translate(Vector3.forward * 0.05f);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                if (!crouching)
                {
                    crouching = true;
                    movementControl("crouch");
                }
                else
                    crouching = false;

            }
            else
            {
                if (!crouching) {
                    speed = w_speed;
                    movementControl("Idle");
                }
                else if(crouchwalk)
                {
                    movementControl("crouch");
                    crouchwalk = false;
                }
                
            }

            //moving right and left
            if (Input.GetKey(KeyCode.A) || Input.GetKey("left"))
            {
                rotSpeed = rot_speed;
            }

            else if (Input.GetKey(KeyCode.D) || Input.GetKey("right"))
            {
                rotSpeed = rot_speed;
            }
            else
            {
                rotSpeed = 0;
            }
        }
        var z = Input.GetAxis("Vertical") * speed;
        var y = Input.GetAxis("Horizontal") * rotSpeed;
        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);

        //jummping function 
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            anim.SetTrigger("isJumping");
            rp.AddForce(0, jumpHeight * Time.deltaTime, 0);
            //isGrounded = false;
        }
    }


}
