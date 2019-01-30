using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMinimapController : MonoBehaviour
{
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        pos.x = playerTransform.position.x;
        pos.z = playerTransform.position.z;
        pos.y = playerTransform.position.y;
        transform.position = pos;
    }
}
