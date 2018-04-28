using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoresc : MonoBehaviour
{
    public static int scoreValue;
    public Text score = null;

    // Use this for initialization
    void Start()
    {
        score = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score :  " + scoreValue;
    }
}
