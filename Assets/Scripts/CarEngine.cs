using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    float y;
    [SerializeField] float speed;
    float turnSpeed;

    [SerializeField] GameObject playerHands;
    Camera cam;
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        speed = 0;
        turnSpeed = 8;
    }

    void Update()
    {
        TurnSides();
        ExitCar();
        Move();
    }

    private void Move()
    {
        y = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W) && speed <= 30)    // 30 max speed
        {
            speed += 4 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Space) && speed >= 0)
        {
            speed -= 4 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && speed >= -30)
        {
            speed -= 4 * Time.deltaTime;
        }       
        transform.Translate(0, 0, speed * Time.deltaTime);
        
    }
    private void ExitCar()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            speed = 0;
            Vector3 trm = transform.position;
            playerHands.gameObject.SetActive(true);
            playerHands.transform.position = new Vector3(trm.x, trm.y + 20, trm.z);
            cam.gameObject.SetActive(false);
            enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enviroment")
        {
            speed = 0;
        }
    }
    private void TurnSides()
    {
        if (speed < 0)
        {
            transform.Rotate(0, -y * turnSpeed, 0);
        }
        else
        {
            transform.Rotate(0, y * turnSpeed, 0);
        }
    }
}
