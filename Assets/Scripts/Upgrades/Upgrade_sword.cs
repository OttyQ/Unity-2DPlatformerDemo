using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour, IUpgradeable
{
    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] SFX_Hero sfx_hero;

    public void ApplyUpgrade()
    {

        playerCombat.AttackEnable();
        sfx_hero.Hero_attack();
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
