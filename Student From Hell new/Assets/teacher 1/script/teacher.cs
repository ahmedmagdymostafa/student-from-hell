using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teacher : MonoBehaviour
{

    public Animator anim;
    private float speed = 0.2f;
    private float rotSpeed = 3.0f;
    static float i = 0;
    public Transform teacher_tenansform;
    public bool Elec = true;
    public static string currentAnimation = "";
    public Light P_light;
    bool start = true;
    bool stop = true;
    bool iswalkenable = false;
    bool iswalkenable2 = false;
    bool iswalkenable3 = false;
    bool iswalkenable4 = false;
    bool iswalkenable5 = false;
    bool iswalkenable6 = false;
    bool iswalkenable7 = false;
    int startstep;
    int endstep;
    public Transform chair;
    public Transform mictable;
    public Transform wall;
    private float walkspped = 0.02f;
    private audiotrigger Au;
    bool islightenable = false;
    public Transform Extension_cable;
    // Use this for initialization
    // Use this for initialization
    void Start()
    {
        teacher_tenansform.Rotate(0, 180, 0);
        mictable = GameObject.FindGameObjectWithTag("podium").transform;
        chair = GameObject.FindGameObjectWithTag("chair").transform;
        wall = GameObject.FindGameObjectWithTag("wall").transform;
        Extension_cable = GameObject.FindGameObjectWithTag("wall").transform;
        explain();

    }

    // Update is called once per frame
    void Update()
    {

        /*if (Au.isangry)
        {
            print("hello");
        }*/
        /* if(Au.isangry)
          {
              this.stop = false;
              anim.SetBool("isangry",true);
              //this.angry();
          }*/

        if (stop)
        {
            

            if (iswalkenable)
            {



                if (mictable.position.x - 1.2f <= transform.position.z)
                {
                    iswalkenable = false;
                    anim.SetBool("iswalk", false);
                    TurnL();
                }
                else
                {
                    anim.SetBool("iswalk", true);
                    anim.SetBool("isTR", false);

                    transform.Translate(0, 0, walkspped);

                }
            }

            if (iswalkenable2)
            {



                if (mictable.position.z + 1.4f >= transform.position.x)
                {
                    iswalkenable2 = false;
                    anim.SetBool("iswalk", false);
                    talk_on_microphone();
                }
                else
                {
                    anim.SetBool("iswalk", true);
                    anim.SetBool("isTR", false);
                    transform.Translate(0, 0, walkspped);

                }
            }

            if (iswalkenable3)
            {



                //if ((transform.position.z) <= -0.4369996)
                if ((transform.position.z) <= chair.position.z - 0.2f)
                {
                    iswalkenable3 = false;
                    anim.SetBool("iswalk", false);
                    turnRtosit();
                }
                else
                {
                    anim.SetBool("isTL", false);
                    anim.SetBool("talklk", false);
                    anim.SetBool("iswalk", true);
                    transform.Translate(0, 0, walkspped);

                }
            }

            if (iswalkenable4)
            {

                if ((transform.position.z) <= chair.position.z - 0.8f)
                {
                    iswalkenable4 = false;
                    anim.SetBool("iswalk", false);
                    turnleft();
                }
                else
                {
                    anim.SetBool("isstand", false);
                    anim.SetBool("iswalk", true);
                    transform.Translate(0, 0, walkspped);

                }
            }

            if (iswalkenable5)
            {
                Debug.Log("wall =>" + wall.position.x);
                Debug.Log(transform.position.x);

                //if ((transform.position.x) >= wall.position.z - 0.4f)
                if ((transform.position.x) >= 4.0f)
                {
                    iswalkenable5 = false;
                    anim.SetBool("iswalk", false);
                    turn180();
                }
                else
                {
                    anim.SetBool("isstand", false);
                    anim.SetBool("iswalk", true);
                    transform.Translate(0, 0, walkspped);

                }
            }
            if (Input.GetKey(KeyCode.L))
            {
                close_light();
            }
        }

        if (!stop)
        {
            if (islightenable)
            {
                islightenable = false;
                anim.SetBool("isexplain", false);
                anim.SetBool("istop", false);
                anim.SetBool("iswalk", false);
                anim.SetBool("isTR", false);
                anim.SetBool("isTL", false);
                anim.SetBool("isexplainsit", false);
                anim.SetBool("issit", false);
                anim.SetBool("isstand", false);
                anim.SetBool("is180", false);
                anim.SetBool("istalk", false);
                transform.rotation = new Quaternion(0, 0, 0, 0);
                anim.Play("walk");
                iswalkenable6 = true;
            }
            if (iswalkenable6)
            {
                if (Extension_cable.position.x - 1.6 <= transform.position.z)
                {
                    iswalkenable6 = false;
                    anim.SetBool("iswalk", false);
                    Picking_Up_Object();
                }
                else
                {
                    anim.SetBool("iswalk", true);
                    transform.Translate(0, 0, walkspped);

                }
            }

            if (iswalkenable7)
            {
                if ((transform.position.z) <= chair.position.z - 0.8f)
                {
                    iswalkenable7 = false;
                    anim.SetBool("iswalk", false);
                    teacher_tenansform.Rotate(0, -90, 0);
                    anim.Play("stop");
                    stop = true;
                    explain();
                }
                else
                {
                    anim.SetBool("iswalk", true);
                    transform.Translate(0, 0, walkspped);

                }
            }
        }


    }

    void close_light()
    {
        P_light.intensity = 0;
        stop = false;
        this.Reacting();
    }
    void start_light()
    {
        P_light.intensity = 8;
    }

    // Update is called once per frame


    void Being_Electrocuted()
    {
        anim.Play("Being Electrocuted", -1, 0f);
        i = 2.25f;
        Invoke("Picking_Up_Object", i);
    }

    public void goanimation(string Animation, float time)
    {
        Invoke(currentAnimation, time);
    }
    public void Reacting()
    {
        anim.Play("Reacting", -1, 0f);
        i = 3.20f;
        Invoke("turnlight", i);

    }

    void turnlight()
    {
        islightenable = true;
    }

    void returntoexplainafterstartlight() 
    {
        transform.rotation = new Quaternion(0, 180, 0, 0);
        anim.Play("walk");
        iswalkenable7 = true;
    }

    void Picking_Up_Object()
    {
        anim.Play("Picking Up Object", -1, 0f);
        i = 2.10f;
        if (Elec)
        {
            Invoke("Being_Electrocuted", i);
            Elec = false;
        }
        else 
        {
            start_light();
            anim.Play("stop");
            Invoke("returntoexplainafterstartlight", i);
        }

    }

    void explain()
    {
        anim.SetBool("isexplain", true);
        anim.SetBool("istop", false);
        anim.SetBool("iswalk", false);
        anim.SetBool("isTR", false);
        anim.SetBool("isTL", false);
        anim.SetBool("isexplainsit", false);
        anim.SetBool("issit", false);
        anim.SetBool("isstand", false);
        anim.SetBool("is180", false);
        anim.SetBool("istalk", false);
        i = 17;
       
        if (stop)
        {
            Invoke("walk", i);
        }
    }

    /*void turnR()
    {
       anim.SetBool("isexplain",false);
       anim.SetBool("istop", false);
       anim.SetBool("iswalk", false);
       anim.SetBool("isTR", true);
       anim.SetBool("isTL", false);
       anim.SetBool("isexplainsit", false);
       anim.SetBool("issit", false);
       anim.SetBool("isstand", false);
       anim.SetBool("is180", false);
       anim.SetBool("istalk", false);
       i = 1.0f;
       Invoke("walk", i);
       
    }*/
    void walk()
    {
        if(stop)
        {
            teacher_tenansform.Rotate(0, -90, 0);
            iswalkenable = true;
        }

    }

    void TurnL()
    {

        transform.Rotate(0, -90, 0);
        if (stop)
        {
            Invoke("walk_to_microphone", 0);
        }
    }
    void walk_to_microphone()
    {
        anim.SetBool("isTL", false);
        iswalkenable2 = true;
    }


    void talk_on_microphone()
    {
        anim.SetBool("isexplain", false);
        anim.SetBool("istop", false);
        anim.SetBool("iswalk", false);
        anim.SetBool("istalk", true);
        anim.SetBool("isTR", false);
        anim.SetBool("isTL", false);
        anim.SetBool("isexplainsit", false);
        anim.SetBool("issit", false);
        anim.SetBool("isstand", false);
        anim.SetBool("is180", false);
        i = 7.2f;
        if (stop)
        {
            Invoke("turnlefttochair", i);
        }
    }

    void turnlefttochair()
    {
        transform.Rotate(0, -90, 0);
        if (stop)
        {
            Invoke("walk_to_chair", 0);
        }
    }

    void walk_to_chair()
    {
        iswalkenable3 = true;

    }

    void turnRtosit()
    {
        anim.SetBool("isexplain", false);
        anim.SetBool("istop", false);
        anim.SetBool("iswalk", false);
        anim.SetBool("isTR", true);
        anim.SetBool("isTL", false);
        anim.SetBool("isexplainsit", false);
        anim.SetBool("issit", false);
        anim.SetBool("isstand", false);
        anim.SetBool("is180", false);
        anim.SetBool("istalk", false);
        i = 1.0f;
        if (stop)
        {
            Invoke("sit", i);
        }
    }

    void sit()
    {
        transform.Rotate(0, 90, 0);
        anim.SetBool("isexplain", false);
        anim.SetBool("istop", false);
        anim.SetBool("iswalk", false);
        anim.SetBool("isTR", false);
        anim.SetBool("isTL", false);
        anim.SetBool("isexplainsit", false);
        anim.SetBool("issit", true);
        anim.SetBool("isstand", false);
        anim.SetBool("is180", false);
        anim.SetBool("istalk", false);
        i = 4.20f;
        if (stop)
        {
            Invoke("explainsitting", i);
        }
    }

    void drink()
    {

    }


    void explainsitting()
    {
        anim.SetBool("isexplain", false);
        anim.SetBool("istop", false);
        anim.SetBool("iswalk", false);
        anim.SetBool("isTR", false);
        anim.SetBool("isTL", false);
        anim.SetBool("isexplainSit", true);
        anim.SetBool("issit", false);
        anim.SetBool("isstand", false);
        anim.SetBool("is180", false);
        anim.SetBool("istalk", false);
        i = 10f;
        if (stop)
        {
            Invoke("Stand_Up", i);
        }
    }

    void Stand_Up()
    {

        anim.SetBool("isexplain", false);
        anim.SetBool("istop", false);
        anim.SetBool("iswalk", false);
        anim.SetBool("isTR", false);
        anim.SetBool("isTL", false);
        anim.SetBool("isexplainSit", false);
        anim.SetBool("issit", false);
        anim.SetBool("isstand", true);
        anim.SetBool("is180", false);
        anim.SetBool("istalk", false);
        i = 4.25f;
        if (stop)
        {
            Invoke("TurnLefttoexplain", i);
        }
    }

    void TurnLefttoexplain()
    {
        transform.Rotate(0, -90, 0);
        if (stop)
        {
            Invoke("step", 0);
        }
    }

    void step()
    {
        iswalkenable4 = true;
    }

    void turnleft()
    {
        transform.Rotate(0, -90, 0);
        walk_to_explain();
    }

    void walk_to_explain()
    {
        iswalkenable5 = true;
    }

    void turn180()
    {
        // transform.Rotate(0, 90, 0);
        startexplain();
    }
    void startexplain()
    {
        //transform.Rotate(0, 90, 0);
        explain();
    }

    public void angry()
    {
        anim.Play("Angry", -1, 0f);
        //i = 3.20f;
        //goanimation(currentAnimation, 3.20f);

    }
}
