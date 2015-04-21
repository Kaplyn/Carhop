using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour
{
    GameObject player;
    public GameObject jumpobj;
    PlayerMovement playermovement;
    public bool mouseDown;
    public float timeMouseDown;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playermovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (mouseDown) { 
            timeMouseDown += Time.deltaTime; 
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        mouseDown = true;
    }
    public void OnPointerUp(BaseEventData eventData)
    {
        mouseDown = false;
        timeMouseDown = 0;
    }
    public void TouchJump()
    {
        playermovement.jumpspeed = 18;
        playermovement.Jump();
    }
}
