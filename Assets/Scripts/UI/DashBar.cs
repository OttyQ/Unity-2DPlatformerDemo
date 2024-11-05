using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    [SerializeField] private Image totalDashBar;
    [SerializeField] private Image currentDashBar;

    private void OnEnable()
    {
        totalDashBar.fillAmount = PlayerDash.instance.GetTotalDashAmount() / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentDashBar.fillAmount = PlayerDash.instance.GetDashAmount() / 10;
        
    }
}
