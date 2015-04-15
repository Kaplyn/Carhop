using UnityEngine;
using System.Collections;

public class MainCenter : MonoBehaviour 
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
		if (other.gameObject.layer == 8){playermovement.centermag = 0f; playermovement.magstrength = 0.02f;}
	}
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.layer == 8){playermovement.magstrength = 0.0f;}
	}
}
