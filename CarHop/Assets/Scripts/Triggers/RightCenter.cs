using UnityEngine;
using System.Collections;

public class RightCenter : MonoBehaviour 
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
		if (other.gameObject.layer == 8){playermovement.centermag = 10f; playermovement.magstrength = 0.02f;}
	}
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.layer == 8){playermovement.magstrength = 0.0f;}
	}
}
