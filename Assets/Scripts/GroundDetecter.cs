using UnityEngine;
using System.Collections;

public class GroundDetecter : MonoBehaviour
{
    public bool isfrontLeft;
    public bool isfrontRight;
    public bool isbackLeft;
    public bool isbackRight;
    public float range = 0.05f;
    Ray shootRay;
    RaycastHit shootHit;
    GameObject player;
    PlayerMovement playermovement;
    bool grounded;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playermovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update() 
    {
        shootRay.origin = transform.position;
        shootRay.direction = -transform.up;

        if (Physics.Raycast(shootRay, out shootHit, range)) {
            playermovement.grounded = true;
            grounded = true;
        } else { 
            grounded = false; 
        }

        if (grounded == false) {
            if (isfrontLeft) { 
                playermovement.frontleftrayfailed = true; 
            }
            if (isfrontRight) { 
                playermovement.frontrightrayfailed = true; 
            }
            if (isbackLeft) { 
                playermovement.backleftrayfailed = true; 
            }
            if (isbackRight) { 
                playermovement.backrightrayfailed = true; 
            }
        }
        if (grounded == true) {
            if (isfrontLeft) {
                playermovement.frontleftrayfailed = false;
            }
            if (isfrontRight) { 
                playermovement.frontrightrayfailed = false; 
            }
            if (isbackLeft) { 
                playermovement.backleftrayfailed = false; 
            }
            if (isbackRight) { 
                playermovement.backrightrayfailed = false; 
            }
        }
    }
}