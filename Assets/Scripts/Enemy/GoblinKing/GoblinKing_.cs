using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GoblinKing_ : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject hpBar;
    public bool isFlipped = false;
    Rigidbody2D rb;
    private SFX_Boss sfx_boss;

    [SerializeField] GameObject EndGame;

    private void Awake()
    {
        sfx_boss = GetComponent<SFX_Boss>();
    }
    private void OnEnable()
    {
        sfx_boss.Boss_theme();
        hpBar.SetActive(true);
    }
    
    private void OnDisable()
    {
        rb = GetComponent<Rigidbody2D>();
        hpBar.SetActive(false);
        rb.velocity = Vector2.zero;
        Physics2D.IgnoreLayerCollision(7, 8, true);

    }
    public void LookAtPlayer()
    {
        // Если объект смотрит вправо изначально
        if (transform.position.x > player.position.x && transform.localScale.x > 0)
        {
            Flip(); // Повернуть влево
        }
        else if (transform.position.x < player.position.x && transform.localScale.x < 0)
        {
            Flip(); // Повернуть вправо
        }
    }

    private void Flip()
    {
        // Меняем только масштаб по оси X для разворота объекта
        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;  // Инвертируем ось X

        transform.localScale = flipped; // Применяем новый масштаб
        isFlipped = !isFlipped; // Меняем статус флага
    }

    public void HandleDie()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EndGame?.SetActive(true);
    }
}
