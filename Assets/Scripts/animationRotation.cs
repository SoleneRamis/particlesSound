using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationRotation : MonoBehaviour
{
    public float speed = 1.0f;

    void Start()
    {
    }


    void Update()
    {
    }

    private void FixedUpdate()
    {
        Quaternion rotation = transform.rotation;
        Vector3 angles = rotation.eulerAngles;

        angles.z += speed;
        rotation.eulerAngles = angles;
        transform.rotation = rotation;
    }
}