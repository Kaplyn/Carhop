using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelStart : MonoBehaviour 
{
	public bool levelstart;
	public bool playeralive = true;

	public float leveltimer;
	public float starttimer;


	public Text text;
	public Text starttext;
	public Text timertext;

	Rigidbody rb;
	GameObject player;
	public GameObject Red;
	public GameObject Orange;
	public GameObject Green;

	void Start () 
	{
		text.text = "";
		timertext.text = "";

		player = GameObject.FindGameObjectWithTag ("Player");
		rb = player.GetComponent <Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
	}
	void Update () 
	{
		if(playeralive == true){starttimer += Time.deltaTime;}
		if(starttimer >= 1){starttext.text = "3";}
		if(starttimer >= 2){starttext.text = "2"; Red.SetActive (true);}
		if(starttimer >= 4){starttext.text = "1"; Red.SetActive (false); Orange.SetActive (true);}
		if(starttimer >= 6){starttext.text = "GO!"; levelstart = true; Orange.SetActive (false); Green.SetActive (true);}
		if(starttimer >= 7){starttext.text = "";}

		if (levelstart) 
		{
		leveltimer += Time.deltaTime;
		timertext.text = "Time";
		text.text = ":" + Mathf.Round (leveltimer * 1f) / 1f;
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		}
	}
}
