using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_knife : MonoBehaviour
{
    [SerializeField] KnifeCreate player_knife;
    [SerializeField] SFX_Hero sfx_hero;
    public void ApplyUpgrade()
    {
        sfx_hero.Hero_knife_upgrade();
        player_knife.KnifeEnable();
        gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ApplyUpgrade();
        }
    }
}
