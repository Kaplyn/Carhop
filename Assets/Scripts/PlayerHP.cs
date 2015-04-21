using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHP : MonoBehaviour 
{
	public GameObject Gameover;
	public GameObject pausemenu;
	public GameObject GameOverMusic;
	public GameObject Continuebutton;
	GameObject Startobj;
	LevelStart levelstart;
	PlayerMovement playermovement;

	public int PlayermaxHP = 20;
	public int PlayercurrentHP = 20;
	public int jumpdamage;

	public float maxSP;
	public float currentsp;
	public float dietimer;
	
	public Slider HPSlider;
	public Slider SPSlider;
	
	RectTransform rectrans;
	Rigidbody rb;

	void Start () 
	{
		Startobj = GameObject.FindGameObjectWithTag("Start");
		levelstart = Startobj.GetComponent<LevelStart>();
		playermovement = GetComponent<PlayerMovement>();
		rb = GetComponent<Rigidbody>();

		PlayercurrentHP = PlayermaxHP;
	}
	void Update ()
	{
		HPSlider.value = PlayercurrentHP;
		HPSlider.maxValue = PlayermaxHP;

		SPSlider.value = currentsp;
		SPSlider.maxValue = maxSP;
		if (playermovement.jumping == true) {
            jumpdamage = 2;
        } else {
            jumpdamage = 1;
        }
		if (levelstart.levelstart == true) {
            currentsp -= Time.deltaTime * jumpdamage;
        }
		if (PlayercurrentHP >= 1) {
            dietimer = 0.0f;
        }
		if (PlayercurrentHP <= 0) {
            dietimer += Time.deltaTime;
        }
		if (dietimer >= 8) {
            Time.timeScale = 0.1f; 
            pausemenu.SetActive(true);
        }
	}
	public void TakeDamage(int amount)
	{
		//audio.Play();
		//particleSystem.Play();
		PlayercurrentHP -= amount;
		if (PlayercurrentHP <= 0){ 
            Die();
        }

		Debug.Log("Player took damage");
	}
	public void SPDamage(int amount)
	{
	}
	public void Die()
	{
		levelstart.playeralive = false;
		levelstart.starttimer = 0.0f;
		levelstart.leveltimer = 0.0f;
		levelstart.levelstart = false;
		rb.useGravity = true;
		rb.mass = 20;
		rb.constraints = RigidbodyConstraints.FreezeRotationZ;

		playermovement.enabled = false;
		//Cursor.visible = true;
		//Gameover.SetActive (true);
		//EventSystem.current.SetSelectedGameObject(Continuebutton);
	}
	public void HPbonus(int amount)
	{
		PlayermaxHP += amount;
		PlayercurrentHP = PlayermaxHP;
		HPSlider.value = PlayercurrentHP;
	}
	public void HPHeal(int amount)
	{
		PlayercurrentHP += amount;
		HPSlider.value = PlayercurrentHP;
	}
}