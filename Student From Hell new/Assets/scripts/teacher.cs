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
    bool iswalkenable8 = false;
    bool iswalkenable9 = false;
    int startstep;
    int endstep;
    public string CurrentAnim;
    public string CurrentFun;
    public Transform chair;
    public Transform mictable;
    public Transform wall;
    private float walkspped = 0.02f;
    private audiotrigger Au;
    bool islightenable = false;
    public Transform Extension_cable;
    public static bool closeLight = false;
    public MeshRenderer Trick;
    // Use this for initialization
    // Use this for initialization
    void Start()
    {
        Debug.Log(chair.position);
        teacher_tenansform.Rotate(0, 180, 0);
        mictable = GameObject.FindGameObjectWithTag("podium").transform;
        chair = GameObject.FindGameObjectWithTag("chair").transform;
        wall = GameObject.FindGameObjectWithTag("wall").transform;
        Extension_cable = GameObject.FindGameObjectWithTag("wall").transform;
        Trick = GameObject.FindGameObjectWithTag("trick").GetComponent<MeshRenderer>();
        explain();

    }
    void explainagine()
    {
        stop = true;
        anim.Play(CurrentAnim);
        Invoke(CurrentFun, 0);
    }
    // Update is called once per frame
    void golab() 
    {
        teacher_tenansform.Rotate(0, 180, 0);
        anim.Play("walk");
        iswalkenable8 = true;
    }
    void returnslide() 
    {
        Trick.enabled = false;
        teacher_tenansform.Rotate(0, 180, 0);
        anim.Play("walk");
        iswalkenable9 = true;
    }
    void Update()
    {
        if ((stop == true) && CurrentAnim == "explain" && (Trick.enabled == true))
        {
            stop = false;
            anim.Play("Reacting");
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
            Invoke("golab", 3.20f);
        }
        if (closeLight)
        {
            closeLight = false;
            close_light();
        }

         if(audiotrigger.isangry)
          {
            audiotrigger.isangry = false;
            Debug.Log("hello");
            this.stop = false;
            //anim.SetBool("isangry",true);
            //anim.Play("Angry");
            this.angry();
           // this.stop = true;
           

          }
         
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

            if (iswalkenable8)
            {
                if (mictable.position.z + 1.4f >= transform.position.x)
                {
                    iswalkenable8 = false;
                    anim.SetBool("iswalk", false);
                    anim.Play("pick");
                    Invoke("returnslide", 1.10f);
                }
                else
                {
                    anim.SetBool("iswalk", true);
                    transform.Translate(0, 0, walkspped);

                }
            }

            if (iswalkenable9)
            {
                if ((transform.position.x) >= 4.0f)
                {
                    iswalkenable9 = false;
                    anim.SetBool("iswalk", false);
                    stop = true;
                    anim.Play("explain");
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
        CurrentAnim = "explain";
        CurrentFun = "explain";
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
       anim.SetBool("isst
       and", false);
       anim.SetBool("is180", false);
       anim.SetBool("istalk", false);
       i = 1.0f;
       Invoke("walk", i);
       
    }*/
    void walk()
    {
        CurrentAnim = "walk";
        CurrentFun = "walk";
        if (stop)
        {
            teacher_tenansform.Rotate(0, -90, 0);
            iswalkenable = true;
        }

    }

    void TurnL()
    {
        CurrentAnim = "";
        CurrentFun = "TurnL";
        transform.Rotate(0, -90, 0);
        if (stop)
        {
            Invoke("walk_to_microphone", 0);
        }
    }
    void walk_to_microphone()
    {
        CurrentAnim = "walk";
        CurrentFun = "walk_on_microphone";
        anim.SetBool("isTL", false);
        iswalkenable2 = true;
    }


    void talk_on_microphone()
    {
        CurrentAnim = "talk";
        CurrentFun = "talk_on_microphone";
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
        CurrentAnim = "";
        CurrentFun = "turnlefttochair";
        if (stop)
        {
            transform.Rotate(0, -90, 0);
            Invoke("walk_to_chair", 0);
        }
    }

    void walk_to_chair()
    {
        CurrentAnim = "walk";
        CurrentFun = "walk_to_chair";
        if (stop)
        {
            iswalkenable3 = true;
        }

    }

    void turnRtosit()
    {
        CurrentAnim = "Rturn";
        CurrentFun = "turnRtosit";
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
        CurrentAnim = "sit";
        CurrentFun = "sit";
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
        CurrentAnim = "explain";
        CurrentFun = "explainsitting";
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
        CurrentAnim = "standup";
        CurrentFun = "Stand_Up";
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
        CurrentAnim = "";
        CurrentFun = "TurnLefttoexplain";
        transform.Rotate(0, -90, 0);
        if (stop)
        {
            Invoke("step", 0);
        }
    }

    void step()
    {
        CurrentAnim = "walk";
        CurrentFun = "step";
        iswalkenable4 = true;
    }

    void turnleft()
    {
        CurrentAnim = "";
        CurrentFun = "turnleft";
        transform.Rotate(0, -90, 0);
        walk_to_explain();
    }

    void walk_to_explain()
    {
        CurrentAnim = "walk";
        CurrentFun = "walk_to_explain";
        iswalkenable5 = true;
    }

    void turn180()
    {
        // transform.Rotate(0, 90, 0);
        CurrentAnim = "";
        CurrentFun = "turn180";
        startexplain();
    }
    void startexplain()
    {
        //transform.Rotate(0, 90, 0);
        CurrentAnim = "";
        CurrentFun = "startexplain";
        explain();
    }

    public void angry()
    {
       // CurrentAnim = "Angry";
       // CurrentFun = "angry";
        anim.Play("Angry");
        iswalkenable = false;
        iswalkenable2 = false;
        iswalkenable3 = false;
        iswalkenable4 = false;
        iswalkenable5 = false;
        iswalkenable6 = false;
        iswalkenable7 = false;
        Invoke("explainagine", 18.20f);

    }
}
