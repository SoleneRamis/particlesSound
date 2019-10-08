using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamSound : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        source.Play();
    }

}
