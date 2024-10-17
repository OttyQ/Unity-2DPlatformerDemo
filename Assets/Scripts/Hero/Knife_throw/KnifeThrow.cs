using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Animator KnifeAnim;

    public float lifetime = 5f; // ����� ����� ����
    private Rigidbody2D rb;
    private Health enemyHealth;
    private int newLayer; // ����� ������ ����
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime); // ���������� ��� ����� �������� �����
        //newLayer = LayerMask.NameToLayer(newLayerName); // �������� ����� ���� �� �����
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
            //StickKnife(); // ��� ������������ �� ������ ����������� ���
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

    //�������� ���� � �����
    //void StickKnife()
    //{
    //    rb.velocity = Vector2.zero; // ������������� ��������
    //    rb.angularVelocity = 0f; // ������������� ��������
    //    rb.gravityScale = 0; // ��������� ����������
    //    rb.isKinematic = true; // ������ ������ ��������������

    //    // �������� ����, ����� �������������� �������
    //    if (newLayer != -1) // ��������, ��� ���� ����������
    //    {
    //        gameObject.layer = newLayer;
    //    }
    //    GameObjectUtility.SetStaticEditorFlags(gameObject, StaticEditorFlags.BatchingStatic);
    //    // transform.SetParent(null); // ���������� ������ �� �������� (���� ����)
    //}
}