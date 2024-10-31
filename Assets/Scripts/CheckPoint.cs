using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Spawning HeroSpawnGameController;
    [SerializeField] Health heroHealth; 
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
        if (HeroSpawnGameController != null)
        {
            Vector2 curCheck = transform.position;
            if (HeroSpawnGameController.CheckPointPos != curCheck)
            {
                Instantiate(effect, transform.position, Quaternion.identity);//particle activation
                HeroSpawnGameController.UpdateCheckPoint(transform.position);
                sfx_shrine.Shrine_Activate();
                heroHealth.currentHealth = heroHealth.startingHealth;
                ShrineSpriteRenderer.sprite = ActivatedShrineSprite; //shrine sprite change to activated
            } 
            else
            {
                Instantiate(effect, transform.position, Quaternion.identity);//particle activation
                sfx_shrine.Shrine_Activate_alt();
            }
        }
            

        
        

        
        
           
        
    }
}
