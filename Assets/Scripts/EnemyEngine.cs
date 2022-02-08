using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyEngine : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAngent;
    float distance = Mathf.Infinity;
    [SerializeField] int enemyLives;
    public int currentLives;
    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        currentLives = enemyLives;
        navMeshAngent = GetComponent<NavMeshAgent>();       
    }
    // Update is called once per frame
    void Update()
    {
        EnemyDead();
        
        AttackTarget();
    }
    private void FixedUpdate()
    {
        ChekDictanse();
    }
    private void ChekDictanse()
    {
        distance = Vector3.Distance(transform.position, target.position);
        if (isDead == false)
        {          
            if (currentLives != enemyLives) 
            {
                ChaseTarget();
            }
            else
            {
                navMeshAngent.SetDestination(transform.position);
                GetComponent<Animator>().SetBool("Walke", false);
            }
        }        
    }
    private void ChaseTarget()
    {
        if (isDead == false)
        {
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Animator>().SetBool("Walke", true);
            navMeshAngent.SetDestination(target.position);
        }
    }
    private void AttackTarget()
    {
        if (distance <= navMeshAngent.stoppingDistance)
        {
            GetComponent<Animator>().SetBool("Attack", true);
        }       
    }
    public void Damage()  // Event in animator
    {
        PlayerLives lives = FindObjectOfType<PlayerLives>();
        lives.TakeDamage();
        DisplayDamage damage = FindObjectOfType<DisplayDamage>();
        damage.DamageImage();
    }
    private void EnemyDead()
    {
        if(currentLives <= 0)
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("Die");
            navMeshAngent.SetDestination(transform.position);
            Destroy(gameObject, 6f);
        }
    }
    public void TakeDamage(int damage)
    {
        currentLives -= damage;
    }   
}
