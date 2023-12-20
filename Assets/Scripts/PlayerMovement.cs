using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{

    private float dashTime = 0f;
    public float dashLimit = 1f;

    public Camera fpsCam;

    public CharacterController controller;
    private float speedNormal;
    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float drag = .8f;
    private bool isDashing = false;
    public Transform groundCheck;
    public float dashSpeed = 30f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private Vector3 move;
   StaminaBar stamina;
    public int fov;
    public int dashFov;

    


    bool isGrounded;
    bool isMoving;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        fpsCam.fieldOfView = fov;
        speedNormal = speed;
        stamina = GameObject.FindFirstObjectByType<StaminaBar>();
        //var obj = Instantiate(stamina,);
        //obj.
    }

    // Update is called once per frame
    void Update()
    {

        if (IsOwner)
        {


            fpsCam.enabled = true;
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


      

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");



            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -1f;
            }



            velocity.y += gravity * Time.deltaTime;


            move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            Jump();
            Dash();

            controller.Move(velocity * Time.deltaTime);
     
        }
    }


    void Jump()
    {

      
         
       
            if (Input.GetButtonDown("Jump") /*&& isGrounded*/)
            {
            if (stamina.GetStamina() >= 10f)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                stamina.SetStamina(stamina.GetStamina() - 10);
            }
            }
      
}

    void Dash()
    {
      
        if (Input.GetButtonDown("Dash"))
        {
            if (stamina.GetStamina() >= 99f)
            {
                Debug.Log("dashing");
                isDashing = true;
                dashTime = 0f;
                stamina.SetStamina(0);
            }
        }

        if (isDashing == true)
        {
            if (dashTime < dashLimit)
            {
                speed = dashSpeed;
               // controller.Move(transform.forward *  dashSpeed * Time.deltaTime);
    
                fpsCam.fieldOfView = dashFov;
                
            }
            else
            {
        
                isDashing = false;
                speed = speedNormal;
                fpsCam.fieldOfView = fov;
            }

            dashTime += Time.deltaTime;
        }
    }
}
