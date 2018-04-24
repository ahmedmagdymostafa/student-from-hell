using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotrigger : MonoBehaviour {
    public AudioClip newtrack;
    private audiomanager theAM;
    public AudioClip oldtrack;
    public static bool isangry = false;
    private laughingscript laughing;
    public AudioClip la;
    //public Animator doctor_animator;

    // Use this for initialization
    void Start () {
        theAM = FindObjectOfType<audiomanager>();
        laughing = FindObjectOfType<laughingscript>();
        //laughing.BGM.Stop();
        //   doctor_animator = GameObject.FindGameObjectWithTag("teacher").GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        
        isangry = true;
        theAM.changeBGM(newtrack);
        laughing.changeBGM(la);
        Invoke("changeagaine", 17f);
        
        
    }

    private void changeagaine()
    {
        //laughing.Stop();
        theAM.changeBGM(oldtrack);
    }

}
