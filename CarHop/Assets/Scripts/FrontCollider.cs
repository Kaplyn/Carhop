using UnityEngine;
using System.Collections;

public class FrontCollider : MonoBehaviour 
{
	GameObject player;
	PlayerMovement playermovement;
	PlayerHP playerhp;
	Rigidbody rb;
	public int colliderdamage;
	public int colliderdamage2;
	public int colliderdamage3;
	public int propcolliderdamage2;
	public int propcolliderdamage3;
	
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playermovement = player.GetComponent <PlayerMovement> ();
		playerhp = player.GetComponent <PlayerHP> ();
		rb = player.GetComponent <Rigidbody> ();
	}
	void OnTriggerEnter (Collider other)
	{
		if(rb.velocity.z > 25 && other.gameObject.layer == 9){playerhp.TakeDamage (colliderdamage);}
		if(rb.velocity.z > 30 && other.gameObject.layer == 9){playerhp.TakeDamage (colliderdamage2);}
		if(rb.velocity.z > 40 && other.gameObject.layer == 9){playerhp.TakeDamage (colliderdamage3);}

		if(rb.velocity.z > 30 && other.gameObject.layer == 10){playerhp.TakeDamage (propcolliderdamage2);}
		if(rb.velocity.z > 40 && other.gameObject.layer == 10){playerhp.TakeDamage (propcolliderdamage3);}
	}
}