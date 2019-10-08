using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationWall5 : MonoBehaviour
{
    private Vector3 _initPosition;

    void Start()
    {
        _initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


    void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, _initPosition.y - Mathf.Sin(Time.time), transform.position.z);
    }
}
