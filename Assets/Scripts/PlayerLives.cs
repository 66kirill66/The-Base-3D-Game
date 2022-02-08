using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int health;
    [SerializeField] GameObject deadCanvas;

    void Start()
    {
        deadCanvas.SetActive(false);
    }
    void Update()
    {
        if(health <= 0)
        {
            deadCanvas.SetActive(true);
            Time.timeScale = 0f; // freeze the game
            Weapon wn = FindObjectOfType<Weapon>();
            if (wn != null)
            {
                wn.enabled = false;
            }
            GranadeThrower gThrow = FindObjectOfType<GranadeThrower>();
            if (gThrow != null)
            {
                gThrow.enabled = false;
            }
            FindObjectOfType<Swicher>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            
        }
    }
    public void TakeDamage()
    {
        health--;      
    }
    public void AddLives()
    {
        health++;
    }
}
