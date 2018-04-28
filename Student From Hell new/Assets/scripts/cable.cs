using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cable : MonoBehaviour {
    public Animator studentanim;
    public Transform student_transform;
    public Transform Cable;
    public Light P_light;
    public teacher t;
    void start() 
    {
        student_transform = GameObject.FindGameObjectWithTag("Student").transform;
        Cable = GameObject.FindGameObjectWithTag("Student tools").transform;
        studentanim = GameObject.FindGameObjectWithTag("Student").GetComponent<Animator>();
    }
    void OnMouseDown()
    {
        Debug.Log("cx");
        dopick();
    }
    void dopick()
        {
            Debug.Log("c");
            studentanim.Play("pick");
            studentanim.SetBool("ispick", true);
            studentanim.SetBool("isWalkingForward", false);
            studentanim.SetBool("isWalkingBackward", false);
            studentanim.SetBool("isIdle", false);
            studentanim.SetBool("isRunning", false);
            studentanim.SetBool("Stand", false);
            teacher.closeLight = true;
        }

    
}
