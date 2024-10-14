using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
    public float lifetime = 5f; // Время жизни ножа
    private Rigidbody2D rb;

    
    private int newLayer; // Номер нового слоя

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime); // Уничтожаем нож через заданное время
        //newLayer = LayerMask.NameToLayer(newLayerName); // Получаем номер слоя по имени
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            //StickKnife(); // При столкновении со стеной прикрепляем нож
            Debug.Log("Knife stick at wall!");
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Knife hit the enemy!"); // Логируем попадание по врагу
            Destroy(gameObject); // Уничтожаем нож
        }
    }

    //Втыкание ножа в стену
    //void StickKnife()
    //{
    //    rb.velocity = Vector2.zero; // Останавливаем движение
    //    rb.angularVelocity = 0f; // Останавливаем вращение
    //    rb.gravityScale = 0; // Отключаем гравитацию
    //    rb.isKinematic = true; // Делаем объект кинематическим

    //    // Изменяем слой, чтобы распознавалось игроком
    //    if (newLayer != -1) // Убедимся, что слой существует
    //    {
    //        gameObject.layer = newLayer;
    //    }
    //    GameObjectUtility.SetStaticEditorFlags(gameObject, StaticEditorFlags.BatchingStatic);
    //    // transform.SetParent(null); // Открепляем объект от родителя (если есть)
    //}
}