using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTiriggerEnter(Collider other)
    {
        CharacterMove mover = other.gameObject.GetComponent<CharacterMove>();
        mover.Restart();
    }

    private void OnTriggerExit(Collider other)
    {

    }

}
