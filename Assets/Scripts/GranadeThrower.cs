using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GranadeThrower : MonoBehaviour
{
    [SerializeField] GameObject granadePrifab;
    GameObject granade;
    [SerializeField] float forse;
    [SerializeField] Transform throwPos;
    public bool isThrow;
    [SerializeField] int currentAmmo;
    [SerializeField] float sec;
    [SerializeField] Text ammoText;

    void Update()
    {
        ammoText.text = currentAmmo.ToString();
        if (Input.GetMouseButton(0) && isThrow == false)
        {
            StartCoroutine(Shot());
        }
        else
        {
            GetComponent<Animator>().SetBool("Shot", false);
        }
        WalkAnimator();
        RunAnimator();
    }
    private void WalkAnimator()
    {
        bool isMove = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A));
        GetComponent<Animator>().SetBool("Walk", isMove);
    }
    private void RunAnimator()
    {
        bool isRun = Input.GetKey(KeyCode.LeftShift);
        GetComponent<Animator>().SetBool("Run", isRun);
    }  
    IEnumerator Shot()
    {      
        isThrow = true;
        if (currentAmmo > 0)
        {           
            GetComponent<Animator>().SetBool("Shot", true);           
            currentAmmo--;
            yield return new WaitForSeconds(sec);
        }
        isThrow = false;
    }
    public void InstGranade()
    {
        granade = Instantiate(granadePrifab, throwPos.position, transform.rotation);      
    }
    public void ThrowGranade()
    {      
        granade.AddComponent<Rigidbody>();
        SkinnedMeshRenderer m = granade.GetComponentInChildren<SkinnedMeshRenderer>();
        m.enabled = true;
        Rigidbody _rb = granade.GetComponent<Rigidbody>();       
        _rb.AddForce(transform.forward * forse, ForceMode.VelocityChange);
    } 
}
