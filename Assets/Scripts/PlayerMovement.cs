using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float walkacceleration;
    public float maxwalkspeed;
    public float stoppingspeed;
    public float runacceleration;
    public float maxrunspeed;
    public float movefriction;
    public float shieldspeed;
    public float stopspeed;
    public float jumpspeed;
    public float airfriction;
    public float gravityMultiplier;
    public float crouchDownwardForce;
    public float centermag = 0f;
    public float strafewalkacceleration;
    public float mobilespeed;
    public float magstrength;
    public Vector3 movevel;
    public Slider speedslider;

    float direction;

    public int jumppingtimeleft;
    public int totaljumptime;

    public bool RunPowerUP;
    public bool grounded;
    public bool falling;
    public bool crouching;
    public bool jumping;
    public bool Haslanded;
    public bool movingright;
    public bool running;
    public bool frontleftrayfailed;
    public bool frontrightrayfailed;
    public bool backleftrayfailed;
    public bool backrightrayfailed;
    public bool goundfriction;

    bool jumpkeypressed = false;

    Vector3 movedirection = Vector3.forward;
    Vector3 strafemovedirection = Vector3.right;
    Vector3 movementOffSet;
    Rigidbody rb;

    public Transform Savelocal1;
    public Transform Savelocal2;
    public Transform Savelocal3;
    public Transform Savelocal4;

    public GameObject playerlandaudio;
    PlayerHP playerhp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerhp = GetComponent<PlayerHP>();
    }

    void FixedUpdate()
    {
        movevel = rb.velocity;
        if (rb.velocity.z > 0) { 
            strafewalkacceleration = rb.velocity.z; 
        }
        if (rb.velocity.z < 0) { 
            strafewalkacceleration = -rb.velocity.z; 
        }
        //Sound for when player lands
        if (grounded && Haslanded == false) { 
            Haslanded = true; 
        }
        //This section controsl basic movement.
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) { 
            Walk(Input.GetAxis("Vertical"));
            Strafe(Input.GetAxis("Horizontal")); 
        }
        if (Application.platform == RuntimePlatform.Android) { 
            Walk(speedslider.value);
            Strafe(Input.acceleration.x);
            mobilespeed = 4; 
        } else { 
            mobilespeed = 1; 
        }


        //This controls jumping.
        if (Input.GetButton("Jump") && falling == false) { 
            jumpspeed = 10; 
            Jump(); 
        }
        if (frontleftrayfailed && frontrightrayfailed && backleftrayfailed && backrightrayfailed) { 
            grounded = false; 
            Haslanded = false; 
        }
        if (GetComponent<Rigidbody>().velocity.y < -1.5) { 
            falling = true; 
        } else { 
            falling = false; 
        }

        if (transform.position.x != centermag) { 
            movementOffSet.x = (centermag - transform.position.x) * magstrength; 
        }
        transform.Translate(movementOffSet);

        //This controls the characters run speed;
        if (Input.GetButton("Turbo")) {
            running = true; 
        } else { 
            running = false; 
        }

        if (RunPowerUP == true) { 
            maxwalkspeed = 1200; 
            maxrunspeed = 1400; 
            runacceleration = 65; 
        }
        if (RunPowerUP == false && Input.GetAxisRaw("Vertical") >= 0 && goundfriction == false) { 
            maxwalkspeed = 1500; 
            maxrunspeed = 1500; 
            runacceleration = 50;
        }
        if (Input.GetAxisRaw("Vertical") < 0 || goundfriction == true) { 
            maxwalkspeed = 15; 
            maxrunspeed = 15; 
            runacceleration = 50; 
        }

        //These functions need to run every frame.
        ApplyGravity();
        JumpUpdate();
        PlayerFriction();
    }

    public void Walk(float direction)
    {
        float acceleration = walkacceleration;
        if (running) {
            acceleration = runacceleration;
        }
        GetComponent<Rigidbody>().AddForce(movedirection * direction * acceleration, ForceMode.Acceleration);
        stopspeed = 1 - Mathf.Abs(direction);
        if (direction > 0 && movingright) { 
            movingright = false; 
        }
        if (direction < 0 && !movingright) { 
            movingright = true; 
        }
    }

    void Strafe(float strafedirection)
    {
        float strafeacceleration = strafewalkacceleration;
        if (running) {
            strafeacceleration = runacceleration;
        }
        GetComponent<Rigidbody>().AddForce(strafemovedirection * strafedirection * strafeacceleration * mobilespeed, ForceMode.Acceleration);
        //stopspeed = 1 - Mathf.Abs(direction);
        if (strafedirection > 0 && movingright) { 
            movingright = false; 
        }
        if (strafedirection < 0 && !movingright) { 
            movingright = true; 
        }
    }

    void PlayerFriction()
    {
        //applying friction when grounded.
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        if (grounded && stopspeed > 0.0f) {
            Vector3 velocityInGroundDir = Vector3.Dot(velocity, movedirection) * movedirection;
            Vector3 newVelocityInGroundDir = velocityInGroundDir * Mathf.Lerp(1.0f, movefriction, stopspeed);
            velocity -= velocityInGroundDir - newVelocityInGroundDir;
        }
        velocity *= airfriction;
        float frictionspeed = Mathf.Abs(velocity.z);
        float maxSpeed = maxwalkspeed;
        if (running) { 
            maxSpeed = maxrunspeed; 
        }
        if (frictionspeed > maxSpeed) { 
            velocity.z *= maxSpeed / frictionspeed; 
        }
        if (frictionspeed < stoppingspeed && stopspeed == 1.0f) { 
            velocity.z = 0; 
        }
        GetComponent<Rigidbody>().velocity = velocity;
        stopspeed = 1.0f;
    }

    public void Jump()
    {
        jumpkeypressed = true;
        if (jumppingtimeleft == 0 && !jumping && !crouching) {
            if (grounded) {
                jumppingtimeleft = totaljumptime;
                jumping = true;
            }
        }
        if (jumppingtimeleft != 0) {
            Vector3 jumpvel = GetComponent<Rigidbody>().velocity;
            jumpvel.y = jumpspeed;
            GetComponent<Rigidbody>().velocity = jumpvel;
        }
    }

    void JumpUpdate()
    {
        if (!jumpkeypressed && jumping) {
            jumppingtimeleft = 0;
            jumping = false;
        }
        if (jumppingtimeleft != 0) { 
            jumppingtimeleft--; 
        }
        jumpkeypressed = false;
    }

    void ApplyGravity()
    {
        if (!grounded) { 
            GetComponent<Rigidbody>().AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration); 
        }
    }
}