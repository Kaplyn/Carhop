using UnityEngine;
using System.Collections;

public class ConeSpawner : MonoBehaviour 
{
	public int spawnchance;
	public GameObject cone;

	void Start() 
    {
		spawnchance = Random.Range(1, 10);
		if (spawnchance <= 2) {
            Instantiate(cone, transform.position, transform.rotation);
        }
	}
	void Update() 
    {
	
	}
}
