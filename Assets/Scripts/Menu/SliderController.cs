using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public TMP_Text valueText;
    public Slider slider;

    private void Start()
    {
        valueText.text = slider.value.ToString();
    }
    public void OnSliderChanged(float value)
    {
        valueText.text = value.ToString();
    }
}