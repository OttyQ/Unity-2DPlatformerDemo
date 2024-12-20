using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_dash : MonoBehaviour, IUpgradeable
{
    [SerializeField] PlayerMovement playerMove;
    [SerializeField] SFX_Hero sfx_hero;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] private GameObject tipSprite;
    [SerializeField] private float displayDuration = 2f;

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip upgrade;
    public void ApplyUpgrade()
    {
        audioManager.PlaySFX(upgrade);
        PlayerDash.instance.EnableDash();
        sprite.enabled = false;


    }

    public void ShowTip()
    {
        StartCoroutine(DisplayTipCoroutine());
    }

    private IEnumerator DisplayTipCoroutine()
    {
        tipSprite.SetActive(true); 
        yield return new WaitForSeconds(displayDuration); 
        tipSprite.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ApplyUpgrade();
            ShowTip();
            
        }
    }
}
