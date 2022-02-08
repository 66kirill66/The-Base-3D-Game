using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;

    public Transform groundCheck;
    public Transform carTransform;
    float groundDistance = 0.4f;
    float gravity = -9.81f;
    Vector3 velocity;
    public LayerMask groundMask;
    public bool isGrounded;
    public float jumpHeight = 3f;

      
    [SerializeField] Camera _cE;    
    float distanse = Mathf.Infinity;
    bool isEnter;
    [SerializeField] float range;

   [SerializeField] Canvas aimCanvas;

    void Update()
    {
        Run();
        SetCanvasAim();
        PlMove();      
        Gravity();
        Jump();
        EnterTheCar();
        CheckGroundSphere();       
    }
    private void FixedUpdate()
    {
        DistanseFromCar();
    }
    private void PlMove()
    {
        // movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);      
    }
    private void Gravity()
    {
        // gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    private void EnterTheCar()
    {
        if (Input.GetKeyDown(KeyCode.C) && isEnter == true)
        {
            _cE.gameObject.SetActive(true);           
            CarEngine playerto = FindObjectOfType<CarEngine>();
            playerto.enabled = true;
            gameObject.SetActive(false);
            aimCanvas.enabled = false;
        }
    }
    private void CheckGroundSphere()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    private void DistanseFromCar()
    {
        distanse = Vector3.Distance(carTransform.position, transform.position);
        if(distanse <= range)
        {
            isEnter = true;
        }
        else
        {
            isEnter = false;
        }
    }
    private void SetCanvasAim()
    {
        if(enabled == true)    // if script enabled
        {
            aimCanvas.enabled = true;
        }
        else
        {
            aimCanvas.enabled = false;
        }
    }
    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 25;
        }
        else
        {
            speed = 12;
        }
    }
}
