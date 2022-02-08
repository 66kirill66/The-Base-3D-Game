using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    PlayerLives pl;
    private void Awake()
    {
        pl = FindObjectOfType<PlayerLives>();
    }
    private void Start()
    {       
        slider.maxValue = pl.health;
        slider.value = pl.health;
    }
    private void Update()
    {
        slider.value = pl.health;
    }
}
