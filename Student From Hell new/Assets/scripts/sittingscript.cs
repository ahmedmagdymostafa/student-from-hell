using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sittingscript : MonoBehaviour {

    public GameObject character;
    Animator anim;
    bool iswalkingTowards = false;
    public static bool sittingon = false;
    private void OnMouseDown()
    {
        if (!sittingon)
        {
            anim.SetTrigger("isWalk");
            iswalkingTowards = true;
        }

        else
        {
            iswalkingTowards = false;

        }

    }

    // Use this for initialization
    void Start()
    {
        anim = character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iswalkingTowards)
        {

            Vector3 targetDir;
            targetDir = new Vector3(transform.position.x - character.transform.position.x, 0f,
                transform.position.z - character.transform.position.z);
            Quaternion rot = Quaternion.LookRotation(targetDir);
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, rot, 0.05f);
            character.transform.Translate(Vector3.forward * 0.2f);

            if (Vector3.Distance(character.transform.position, this.transform.position) < 4f)
            {
                anim.SetTrigger("isSitting");
                character.transform.rotation = this.transform.rotation;
                iswalkingTowards = false;
                sittingon = true;


            }
        }
    }
}
