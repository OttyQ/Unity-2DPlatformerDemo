using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_dash : MonoBehaviour, IUpgradeable
{
    [SerializeField] PlayerMovement playerMove;
    [SerializeField] SFX_Hero sfx_hero;
    public void ApplyUpgrade()
    {
        sfx_hero.Hero_dash_upgrade();
        playerMove.DashEnable();
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
