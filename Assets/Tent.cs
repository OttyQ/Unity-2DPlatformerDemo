using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject boss;
    private bool hasTriggered = false;

    // Start is called before the first frame update

    int targetLayer;
    private void Start()
    {
        targetLayer = LayerMask.NameToLayer("Hero");
        Debug.Log("Target layer: " +  targetLayer);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == targetLayer && hasTriggered == false)
        {
            animator.SetTrigger("Awake");
            hasTriggered = true;
        }
    }

    void SpawnBoss()
    {
        boss.SetActive(true);
    }
}
