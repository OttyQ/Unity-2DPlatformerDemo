using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KnifeCreate : MonoBehaviour
{
    public GameObject KnifePrefab;
    private Vector2 newPos;
    [Header("Knife params")]
    public bool canThrowKnife = false;
    [SerializeField] private float KnifeSpeed = 10f;
    [SerializeField] private float KnifeCooldown = 1f;
    private float nextKnifeTime = 0f;
    private Transform playerTransform; 

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextKnifeTime && canThrowKnife)
        {
            ThrowKnife(); 
            nextKnifeTime = Time.time + KnifeCooldown;
        }
    }

    void ThrowKnife()
    {
        // Создаём экземпляр ножа
        newPos = transform.position;
        newPos.y -= 0.5f;
        GameObject knife = Instantiate(KnifePrefab, newPos, transform.rotation);
        Rigidbody2D knifeRb = knife.GetComponent<Rigidbody2D>();

        if (knifeRb != null)
        {
            knifeRb.gravityScale = 0;

            // Определяем направление на основе поворота персонажа
            float direction = playerTransform.localScale.x > 0 ? 1f : -1f;

            // Задаём скорость ножа
            knifeRb.velocity = new Vector2(direction * KnifeSpeed, 0);

            // Переворачиваем нож в правильном направлении
            Vector3 knifeScale = knife.transform.localScale;
            knifeScale.x = Mathf.Abs(knifeScale.x) * direction;
            knife.transform.localScale = knifeScale;
        }
    }
}
