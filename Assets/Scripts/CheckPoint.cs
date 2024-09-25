using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Spawning HeroSpawnGameController;
    [Header("Sprite")]
    [SerializeField] SpriteRenderer ShrineSpriteRenderer;
    [SerializeField] private Sprite ActivatedShrineSprite;
    [Header ("Particle")]
    [SerializeField] private GameObject effect;
    public void NewCheckPointSet()
    {
        Instantiate(effect, transform.position, Quaternion.identity);//particle activation

        if (HeroSpawnGameController != null)
        {
           HeroSpawnGameController.UpdateCheckPoint(transform.position);
            ShrineSpriteRenderer.sprite = ActivatedShrineSprite; //shrine sprite change to activated
        }
    }
}
