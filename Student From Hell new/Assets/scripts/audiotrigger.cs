using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotrigger : MonoBehaviour {
    public AudioClip newtrack;
    private audiomanager theAM;
    public  bool isangry = false;

	// Use this for initialization
	void Start () {
        theAM = FindObjectOfType<audiomanager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        isangry = true;
        theAM.changeBGM(newtrack);

    }
}
