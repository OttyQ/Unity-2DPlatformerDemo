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
    private SFX_Shrine sfx_shrine;

    private void Start()
    {
        sfx_shrine = FindObjectOfType<SFX_Shrine>();
    }
    public void NewCheckPointSet()
    {
        Instantiate(effect, transform.position, Quaternion.identity);//particle activation

        if (HeroSpawnGameController != null)
        {
           HeroSpawnGameController.UpdateCheckPoint(transform.position);
           sfx_shrine.Shrine_Activate();
           ShrineSpriteRenderer.sprite = ActivatedShrineSprite; //shrine sprite change to activated
        }
    }
}
