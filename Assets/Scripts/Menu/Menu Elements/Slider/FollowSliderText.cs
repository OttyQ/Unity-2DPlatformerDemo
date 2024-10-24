
using TMPro;
using UnityEngine;

public class FollowSliderText : MonoBehaviour
{
    [SerializeField] private GameObject slider;

    private void Start()
    {
        SetPos();
    }
    private void Update()
    {
        SetPos();
    }

    private void SetPos()
    {
        Vector3 handlePosition = slider.transform.position;
        Vector3 textPosition = gameObject.transform.position;

        textPosition.y = handlePosition.y;
        gameObject.transform.position = textPosition;
    }
    
}
