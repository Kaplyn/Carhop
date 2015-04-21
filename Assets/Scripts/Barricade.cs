using UnityEngine;
using System.Collections;

public class Barricade : MonoBehaviour 
{
	Rigidbody rb;
	void Start() 
    {
		rb = GetComponent<Rigidbody>();
	}
	void OnTriggerEnter(Collider other) 
    {
		if (other.gameObject.layer == 8) {
            rb.useGravity = true; 
            rb.isKinematic = false;
        }
	}
}
