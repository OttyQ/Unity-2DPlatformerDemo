using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour, IUpgradeable
{
    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] SFX_Hero sfx_hero;
    [SerializeField] private GameObject tipSprite;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] private float displayDuration = 2f; 

    public void ApplyUpgrade()
    {
        sfx_hero.Hero_attack();
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
