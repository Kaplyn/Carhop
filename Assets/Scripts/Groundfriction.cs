using UnityEngine;
using System.Collections;

public class Groundfriction : MonoBehaviour
{
    GameObject player;
    PlayerMovement playermovement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playermovement = player.GetComponent<PlayerMovement>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) { 
            playermovement.goundfriction = true; 
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8) { 
            playermovement.goundfriction = false; 
        }
    }
}
