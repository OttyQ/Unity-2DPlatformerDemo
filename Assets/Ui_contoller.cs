using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_contoller : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject Tip;
    public void UiActivate()
    {
        canvas.SetActive(true);
        Tip.SetActive(true);
    }
}
