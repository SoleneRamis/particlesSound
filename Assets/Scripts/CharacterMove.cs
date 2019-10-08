using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float rotateSpeed = 3.0f;
    public float speed = 5.0f;
    public float jumpSpeed = 2.0f;
    
    private Rigidbody _body;
    private Vector3 _inputs;
    private Vector3 _initPosition;
    private Quaternion _initRotation;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _initRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }

    void Update()
    {
        _inputs = Vector3.zero;
        _inputs.z = Input.GetAxis("Vertical");
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        _inputs = transform.TransformDirection(_inputs);    
        if(Input.GetButtonDown("Jump"))
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(jumpSpeed * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        } 
    }
     private void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * speed * Time.fixedDeltaTime);
    }

    public void Restart()
    {
        transform.position = _initPosition;
        transform.rotation = _initRotation;
    }
}
