using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour, IUpgradeable
{
    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] AudioManager audioManager;
    [SerializeField] private GameObject tipSprite;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] private float displayDuration = 2f;

    [SerializeField] private AudioClip upgrade;

    public void ApplyUpgrade()
    {
        audioManager.PlaySFX(upgrade);
        playerCombat.AttackEnable();
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
