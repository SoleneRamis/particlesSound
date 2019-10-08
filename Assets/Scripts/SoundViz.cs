using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundViz : MonoBehaviour
{
   public GameObject sampleBar;
   public float radius = 10f;
   public float maxScale = 5f;

   private AudioSource _source;
   private float[] _samples;
   private GameObject[] _bars;
   private ParticleSystem[] _particles;
   // Start is called before the first frame update
   void Start()
   {
       _source = GetComponent<AudioSource>();
       _samples = new float[256];
       _bars = new GameObject[_samples.Length];
	   _particles = new ParticleSystem[_samples.Length];
       GameObject bar;
	   ParticleSystem particles;
       float a = (2*Mathf.PI)/_bars.Length ;
       for(int i=0;i<_samples.Length; i++) {
           bar = Instantiate<GameObject>(sampleBar, transform);
		   particles = bar.GetComponentInChildren<ParticleSystem>();
           bar.transform.position = new Vector3(Mathf.Sin(i*a) * radius,0f,Mathf.Cos(i*a)*radius);
           _bars[i] = bar;
		   _particles[i] = particles;
       }
   }
   // Update is called once per frame
   void Update()
   {
       _source.GetSpectrumData(_samples, 0,FFTWindow.Blackman);
       Vector3 scale;
       Vector3 position;
       for(int i= 0; i<_samples.Length;i++) {
			scale = _bars[i].transform.localScale;
			scale.y = _samples[i] * maxScale;
			position = _bars[i].transform.localPosition;
			position.y = _samples[i] * maxScale;
			_bars[i].transform.localScale = scale;
			// _bars[i].transform.localPosition = position;
			if(_samples[i] > 0.02f) {
				_particles[i].Play();
			}
       }
   }
}