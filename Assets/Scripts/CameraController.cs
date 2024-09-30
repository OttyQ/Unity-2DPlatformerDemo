using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;
    private float learpSpeed = 1.5f;


    private void Awake()
    {
        if (!player)
        {
            //player = FindObjectOfType<PlayerController>().transform;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.position;
        pos.z = -4f;
        transform.position = Vector3.Lerp(transform.position, pos, learpSpeed * Time.deltaTime);
    }
}
