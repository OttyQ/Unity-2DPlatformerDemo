using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
    public float lifetime = 5f; // ����� ����� ����
    private Rigidbody2D rb;

    
    private int newLayer; // ����� ������ ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime); // ���������� ��� ����� �������� �����
        //newLayer = LayerMask.NameToLayer(newLayerName); // �������� ����� ���� �� �����
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            //StickKnife(); // ��� ������������ �� ������ ����������� ���
            Debug.Log("Knife stick at wall!");
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Knife hit the enemy!"); // �������� ��������� �� �����
            Destroy(gameObject); // ���������� ���
        }
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