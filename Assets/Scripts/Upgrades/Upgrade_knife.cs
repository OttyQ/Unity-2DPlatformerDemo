using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Upgrade_knife : MonoBehaviour, IUpgradeable
{
    [SerializeField] KnifeCreate player_knife;
    //[SerializeField] SFX_Hero sfx_hero;
    [SerializeField] private GameObject tipSprite;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] AudioManager audioManager;
    [SerializeField] private float displayDuration = 2f;

    [SerializeField] private AudioClip upgrade;
    public void ApplyUpgrade()
    {
        audioManager.PlaySFX(upgrade); ;
        player_knife.KnifeEnable();
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
