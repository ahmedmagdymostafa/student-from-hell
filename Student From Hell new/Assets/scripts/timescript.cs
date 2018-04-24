using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 0649
public class timescript : MonoBehaviour {
	public Image timerBar=null;
	public float maxTime=20;
	public float timeLeft;
	//public GameObject TimesUpText;
	// Use this for initialization
	void Start () {
		//TimesUpText.SetActive (false);
		timerBar.GetComponent<Image> ();
		timeLeft = maxTime;

	}

	// Update is called once per frame
	void Update () {
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
			timerBar.fillAmount = timeLeft / maxTime;
		} else {
			//TimesUpText.SetActive (true);
			Time.timeScale = 0;
		}
	}
}
