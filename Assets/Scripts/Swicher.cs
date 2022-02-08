using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swicher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    [SerializeField] AudioClip audioS;  
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetWeaponActive();   // index 0
    }
    void Update()
    {
        int previosWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollWeel();

        if (previosWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }
    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {               
                weapon.gameObject.SetActive(true);
                Weapon weaponShoot = FindObjectOfType<Weapon>();
                if(weaponShoot != null)
                {
                    weaponShoot.canShoot = true;
                }
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
            audioSource.PlayOneShot(audioS);
        }
    }
    private void ProcessScrollWeel()   // +
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)  // -
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }
    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))  // num 1
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))  //num 2
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) // num 3
        {
            currentWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) // num 4
        {
            currentWeapon = 3;
        }
    }   
}
