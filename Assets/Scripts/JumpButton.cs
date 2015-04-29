using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class JumpButton : MonoBehaviour
{
    GameObject player;
    PlayerMovement playermovement;

    public GameObject jumpobj;
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
