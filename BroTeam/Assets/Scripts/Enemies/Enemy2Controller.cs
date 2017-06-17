using UnityEngine;

namespace Enemies
{
	public class Enemy2Controller : MonoBehaviour {

		public GameObject Shot;
		public Transform ShotSpawn;
		public float FireTime;
		public float Delay;

		private AudioSource _audioSource;
	
		void Start ()
		{
			//_audioSource = GetComponent<AudioSource>();
			InvokeRepeating("Fire", Delay, FireTime);
		}

		void Fire()
		{
			Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
			//_audioSource.Play();
		}
	}
}
