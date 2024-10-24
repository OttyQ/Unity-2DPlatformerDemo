
using TMPro;
using UnityEngine;

public class FollowSliderText : MonoBehaviour
{
  
    
        [SerializeField] private GameObject slider;
        

        private void Update()
        {
            Vector3 handlePosition = slider.transform.position;
            Vector3 textPosition = gameObject.transform.position;

            textPosition.y = handlePosition.y;
            gameObject.transform.position = textPosition;
        }
    
}
