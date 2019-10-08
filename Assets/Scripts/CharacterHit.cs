using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHit : MonoBehaviour
{
	public string layerName;
    private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
		_source = GetComponent<AudioSource>();
		Debug.Log("start");
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer(layerName))
		{
			Debug.Log("character hit with : " + collision.gameObject.name);
			_source.Play();
		}
		
	}
}
