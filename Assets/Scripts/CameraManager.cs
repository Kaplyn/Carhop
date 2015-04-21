using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour 
{
	public float smooth = 4f;
	public Transform target;
	public bool zoomout = false;
	public Vector3 offset;
	public float fovspeed;
	public float targetfov;
	bool running;
	GameObject player;
	PlayerMovement playermovement;
	
	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		playermovement = player.GetComponent<PlayerMovement>();
		offset = transform.position - target.position;
	}
	void FixedUpdate() 
    {
		transform.LookAt(target);
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smooth * Time.deltaTime);
		if (zoomout == true) {
			offset.z = -0.0f;
		}
		if (zoomout == false) {
			offset.z = -15.0f;
			targetfov = 40;
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetfov, fovspeed * Time.deltaTime);
		}
		if(Input.GetAxisRaw("Vertical") > 0) {
            smooth = 2; 
            targetfov = 60; 
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetfov, fovspeed * Time.deltaTime);
        }
		if(Input.GetAxisRaw("Vertical") < 0){ 
            smooth = 4; 
            targetfov = 40; 
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetfov, fovspeed * Time.deltaTime);
        }
	}
}