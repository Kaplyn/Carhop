using UnityEngine;
using System.Collections;

public class RightRight : MonoBehaviour 
{
	GameObject player;
	PlayerMovement playermovement;
	
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playermovement = player.GetComponent <PlayerMovement> ();
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.layer == 8){playermovement.centermag = 5f;}
	}
}
