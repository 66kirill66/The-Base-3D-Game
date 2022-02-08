using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : MonoBehaviour
{
    [SerializeField] GameObject red;
    [SerializeField] GameObject green;
    public int hitTarget;

    // Start is called before the first frame update
    void Start()
    {
        hitTarget = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(hitTarget >= 0)
        {
            green.gameObject.SetActive(true);
            red.gameObject.SetActive(false);
        }
        else
        {
            red.gameObject.SetActive(true);
            green.gameObject.SetActive(false);
        }
    }
}
