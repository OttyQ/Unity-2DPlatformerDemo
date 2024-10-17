using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Animator KnifeAnim;

    public float lifetime = 5f; // Время жизни ножа
    private Rigidbody2D rb;
    private Health enemyHealth;
    private int newLayer; // Номер нового слоя
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime); // Уничтожаем нож через заданное время
        //newLayer = LayerMask.NameToLayer(newLayerName); // Получаем номер слоя по имени
        if (KnifeAnim == null)
        {
            KnifeAnim = GetComponent<Animator>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            rb.velocity = Vector3.zero;
            //StickKnife(); // При столкновении со стеной прикрепляем нож
            Debug.Log("Knife stick at wall!");
            KnifeAnim.SetTrigger("Destroy");
            
        }

        if (collision.CompareTag("Enemy"))
        {
            rb.velocity = Vector3.zero;
            enemyHealth = collision.GetComponent<Health>();
            if (enemyHealth == null)
            {
                enemyHealth = collision.GetComponentInParent<Health>();
            }
            if(enemyHealth != null) enemyHealth.TakeDamage(damage);
            KnifeAnim.SetTrigger("Destroy");
            
        }
    }

    public void HandleDestroy()
    {
        Destroy(gameObject);
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