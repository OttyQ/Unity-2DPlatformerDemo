using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{


    [SerializeField] private Health bossHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;

    // Start is called before the first frame update
    void Start()
    {
        totalHealthbar.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthbar.fillAmount = bossHealth.currentHealth / bossHealth.startingHealth;
    }
}
