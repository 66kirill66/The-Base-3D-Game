using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Text clipText;
    [SerializeField] Text ammoText;
    [SerializeField] AudioClip reloadSound;
    [SerializeField] float sec;
    AudioSource audioSource;
    public bool canShoot;
    [SerializeField] int currentAmmo;
    [SerializeField] ParticleSystem shootEf;
    [SerializeField] Camera FPCamera;
    [SerializeField] int damage;
    [SerializeField] GameObject hitEf;
    [SerializeField] GameObject stoneEf;
    public int clip = 3;
    [SerializeField] int shootindDistanse;

    void Start()
    {
        canShoot = true;
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot == true)
        {
            StartCoroutine(Shot());
        }
        else
        {
            GetComponent<Animator>().SetBool("Shot", false);
        }
        WalkAnimator();
        RunAnimator();
        Reload();
        ReCure();
        TextAmmo();
    }
    private void WalkAnimator()
    {
        bool isMove = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A));  // if ButtonDown = true
        GetComponent<Animator>().SetBool("Walk", isMove);
    } 
    private void RunAnimator()
    {
        
        bool isRun = Input.GetKey(KeyCode.LeftShift);      // if ButtonDown = true
        GetComponent<Animator>().SetBool("Run", isRun);
    }
    IEnumerator Shot()
    {
        canShoot = false;
        if (currentAmmo > 0)
        {
            ProcessRecast();
            shootEf.Play();
            audioSource.Play();
            GetComponent<Animator>().SetBool("Shot", true);
            currentAmmo--;
            yield return new WaitForSeconds(sec);
        }
        canShoot = true;
    }
    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && clip > 0)
        {
            audioSource.PlayOneShot(reloadSound);
            GetComponent<Animator>().SetTrigger("Reload");
            currentAmmo = 30;
            canShoot = true;
            clip--;
        }
    }
    private void ReCure()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentAmmo > 0)
        {
            GetComponent<Animator>().SetTrigger("Aid");
            FindObjectOfType<PlayerLives>().AddLives();
            currentAmmo--;
        }
    }
    private void ProcessRecast()
    {
        RaycastHit rey;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out rey, shootindDistanse))
        {
            if (rey.transform.gameObject.tag == "Enemy")
            {
                Instantiate(hitEf, rey.point,transform.rotation);
                EnemyEngine target = rey.transform.GetComponent<EnemyEngine>();              
                target.TakeDamage(damage);
                if (target == null) return;               
            }
            if (rey.transform.gameObject.tag == "Enviroment")
            {
                Instantiate(stoneEf, rey.point,transform.rotation);
            }
            if (rey.transform.gameObject.tag == "Targets")
            {
                Instantiate(stoneEf, rey.point, transform.rotation);
                ShootTarget target = rey.transform.GetComponent<ShootTarget>();
                target.hitTarget--;
            }
            if (rey.transform.gameObject.tag == "Ground")
            {
                Instantiate(stoneEf, rey.point, transform.rotation);
            }
        }
        else
        {
            return; 
        }
    }
    private void TextAmmo()
    {
        ammoText.text = currentAmmo.ToString();
        clipText.text = clip.ToString();
    }
}
    