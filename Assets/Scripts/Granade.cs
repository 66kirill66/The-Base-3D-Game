using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] float timer;
    bool startTimer;
    [SerializeField] GameObject eX;
    float radius = 10;


    void Update()
    {
        Timer();
        if (timer <= 0)
        {          
            eX.SetActive(true);
            SkinnedMeshRenderer skinMesh = GetComponentInChildren<SkinnedMeshRenderer>();
            skinMesh.enabled = false;
            Invoke("Explode", 1f);
            Destroy(gameObject, 1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            startTimer = true;
        }
    }
    private void Timer()
    {
        if(startTimer == true)
        {
            timer -= Time.deltaTime;
        }
       
    }
    public void Explode()
    {
        Collider[] overlapCollayders = Physics.OverlapSphere(transform.position, radius); // Chek Colliders in Sphere radius 
        for (int i = 0; i < overlapCollayders.Length; i++)
        {
            EnemyEngine en = overlapCollayders[i].GetComponent<EnemyEngine>(); //get enemy script on gameobject with collider
            
            if (en != null)
            {
                en.TakeDamage(10);
            }
        }        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);      
    }
}
