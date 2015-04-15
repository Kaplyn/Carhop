using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour 
{
	public GameObject pausemenu;
	public bool menuup;

	public float timer;

	void Awake () 
	{
		Time.timeScale = 1.0f;
	}

	void Update () 
	{
		timer += Time.deltaTime;
		if(Input.GetKeyDown(KeyCode.Escape) && timer > 0.2f && menuup == false){timer = 0.0f; pausemenu.SetActive (true); menuup = true; Time.timeScale = 0.1f;}
		if(Input.GetKeyDown(KeyCode.Escape) && timer > 0.01f && menuup == true){timer = 0.0f; pausemenu.SetActive (false); menuup = false; Time.timeScale = 1.0f;}
	}
	public void Retry()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	public void Continue()
	{      
		pausemenu.SetActive (false);
	}
	public void Low()
	{

	}
	public void Medium()
	{

	}
	public void High()
	{

	}
}
