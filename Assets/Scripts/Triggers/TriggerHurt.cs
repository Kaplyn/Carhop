using UnityEngine;
using System.Collections;

public class TriggerHurt : MonoBehaviour 
{
	GameObject player;
	PlayerHP playerhp;
	Rigidbody rb;

	float timer;
	bool hashurt;
	public int damage;

	void Start() 
    {
		player = GameObject.FindGameObjectWithTag("Player");
		playerhp = player.GetComponent<PlayerHP>();
		rb = player.GetComponent<Rigidbody>();
	}
	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.layer == 8 && hashurt == false && rb.velocity.z > 1) {
            playerhp.TakeDamage(damage); 
            hashurt = true;
        }
	}
	void OnTriggerExit(Collider other)
    {
		hashurt = false;
	}
}
