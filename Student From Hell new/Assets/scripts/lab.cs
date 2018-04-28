﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class labtop : MonoBehaviour
{
    // Use this for initialization
    public Animator studentanim;
    public MeshRenderer Trick;
    void Start()
    {
        Trick = GameObject.FindGameObjectWithTag("trick").GetComponent<MeshRenderer>();
        Trick.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
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
        Trick.enabled = true;
    }

}