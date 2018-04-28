using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour {
    public bool seePlayer = false;
    public static bool tutnonai = false;
    public GameObject player = null;
    public float turnspeed =- 1f;
    public float maxturn = 45f;
    public float lineOfSight = 3.5f;
    public float maxsight = 8;

    // Update is called once per frame
    void Update () {
        if(tutnonai)
        {
            if (!seePlayer)
            {
                transform.Rotate(0, turnspeed, 0);
                if ((transform.rotation.eulerAngles.y > maxturn && transform.rotation.eulerAngles.y < 180) ||
                   (transform.rotation.eulerAngles.y < 360 - maxturn && transform.rotation.eulerAngles.y > 180))

                    turnspeed =-1 ;
            }
            else
                transform.LookAt(player.transform);
            
        }
        Vector3 sight = player.transform.position - transform.position;
        float dot = Vector3.Dot(sight, transform.right);
        if (dot < lineOfSight && dot > -lineOfSight)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized, out hit, maxsight))
            {
                if (hit.collider.name == "aj@Idle")
                {
                    seePlayer = true;
                    teacher.stopgame = true;
                    transform.LookAt(player.transform);
                    if(scoresc.scoreValue>0)
                    {
                        scoresc.scoreValue -= 1;
                    }
                    else
                    {
                        FindObjectOfType<GameManagerscene2>().endgame();
                    }
                }
                else
                    seePlayer = false;

            }
            else
                seePlayer = false;
        }
      
        
        

        }

}
