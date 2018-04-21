using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_animation : MonoBehaviour {

    public Animator anim;
    public int stop = 0;
    public float i = 1;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        Invoke("anime", 0f);
	}
	
	// Update is called once per frame
    void Update(){
        

	}

    void anime() 
    {
        int rand = Random.Range(1,6);
        string animation = rand.ToString();
        anim.Play(animation, -1, 0f);
        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).length);
        i = anim.GetCurrentAnimatorStateInfo(0).length + 1;
        Invoke("anime",i);
          //System.Threading.Thread.Sleep(5000);
    }
}
