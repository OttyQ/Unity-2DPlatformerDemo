using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KnifeCreate : MonoBehaviour
{
    public GameObject KnifePrefab;
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
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextKnifeTime)
        {
            ThrowKnife(); 
            nextKnifeTime = Time.time + KnifeCooldown;
        }
    }

    void ThrowKnife()
    {
        // Создаём экземпляр ножа
        GameObject knife = Instantiate(KnifePrefab, transform.position, transform.rotation);
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
