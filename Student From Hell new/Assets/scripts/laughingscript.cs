using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laughingscript : MonoBehaviour {
    public AudioSource BGM;

    // Use this for initialization
    void Start()
    {
        BGM.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeBGM(AudioClip music)
    {
        BGM.clip = music;
        BGM.Play();

    }
}
