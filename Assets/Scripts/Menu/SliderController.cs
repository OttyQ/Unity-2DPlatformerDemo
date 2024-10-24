using UnityEngine;
using TMPro;

public class SliderController : MonoBehaviour
{
    public TMP_Text valueText;

    public void OnSliderChanged(float value)
    {
        float curVal = value * 10f;

        
        int roundedVal = Mathf.RoundToInt(curVal);
        valueText.text = roundedVal.ToString();
    }
}