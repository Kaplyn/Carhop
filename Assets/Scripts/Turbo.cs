using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Turbo : MonoBehaviour
{

    GameObject player;
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
        if (mouseDown)
        {
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

    public void ButtonTouched()
    {
    }
}
