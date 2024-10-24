using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ChangeButtonTexture : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite pressedSprite;
    public GameObject arrows;
    public GameObject arrowsPressed;
    public Transform buttonTransform;
    private Sprite originalSprite;
    private Image buttonImage;
    private Vector3 buttonOriginalPos;
    private float buttonPressOffset = 10f; // Amount to move the button down when pressed

    [Header ("Audio")]
    private AudioManagerMenu audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerMenu>();
        buttonImage = GetComponent<Image>();
        originalSprite = buttonImage.sprite;
        buttonOriginalPos = transform.position;
        arrows.SetActive(false); // Initially hide the arrows
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioManager.PlaySFX(audioManager.buttonSelect);
        arrows.SetActive(true);
        SetArrowsPosition(arrows); // Set arrows position when pointer enters the button
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        arrows.SetActive(false); // Hide the arrows GameObject when pointer exits the button
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        audioManager.PlaySFX(audioManager.buttonPress);
        buttonImage.sprite = pressedSprite;
        SetButtonPosition(true);
        arrows.SetActive(false); // Hide the normal arrows GameObject
        arrowsPressed.SetActive(true);
        SetArrowsPosition(arrowsPressed); // Set arrows position when button is pressed
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = originalSprite;
        SetButtonPosition(false);
        arrows.SetActive(true); // Show the normal arrows GameObject
        arrowsPressed.SetActive(false); // Hide the pressed arrows GameObject
        SetArrowsPosition(arrows); // Set arrows position when button is released
    }

    void SetArrowsPosition(GameObject arrows)
    {
        Vector3 buttonPosition = transform.position;
        Vector3 arrowsPosition = arrows.transform.position;
        arrowsPosition.y = buttonPosition.y;
        if (arrows == arrowsPressed)
        {
            arrowsPosition.y -= 10f;
        }
        arrows.transform.position = arrowsPosition;
    }

    void SetButtonPosition(bool isPressed)
    {
        Vector3 buttonPosition = buttonOriginalPos;
        if (isPressed)
        {
            buttonPosition.y -= buttonPressOffset;
        }
        buttonTransform.position = buttonPosition;
    }
}