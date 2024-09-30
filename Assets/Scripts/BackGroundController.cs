using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{

    private float startPosX, startPosY, length;
    public GameObject cam;
    public float parallaxEffectX, parallaxEffectY;
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceX = cam.transform.position.x * parallaxEffectX;
        float distanceY = cam.transform.position.y * parallaxEffectY;// 0 - move with camera || 1 - won't move

        float movement = cam.transform.position.x * (1 - parallaxEffectX);

        transform.position = new Vector3(startPosX + distanceX, startPosY + distanceY, transform.position.z);

        if (movement > startPosX + length)
        {
            startPosX += length;
        }
        else if (movement < startPosX - length)
        {
            startPosX -= length;
        }

    }
}
