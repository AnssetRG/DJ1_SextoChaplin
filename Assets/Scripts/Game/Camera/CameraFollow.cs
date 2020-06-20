using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [HideInInspector]
    public Vector3 startPosition;
    private float minCameraX = 0f, maxCameraX = 14f;

    [HideInInspector]
    public bool isFollowing;
    [HideInInspector]
    public Transform birdToFollow;
    public static CameraFollow instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            if (birdToFollow != null)
            {
                Vector3 birdPosition = birdToFollow.position;
                float x = Mathf.Clamp(birdPosition.x, minCameraX, maxCameraX);
                transform.position = new Vector3(x, startPosition.y, startPosition.z);
            }
            else
            {
                isFollowing = false;
            }
        }
    }
}
