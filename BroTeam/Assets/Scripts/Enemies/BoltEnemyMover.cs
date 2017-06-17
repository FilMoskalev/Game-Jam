using UnityEngine;

namespace Enemies
{
	public class BoltEnemyMover : MonoBehaviour {

		public float Speed;

		void Start ()
		{
			GetComponent<Rigidbody>().velocity = transform.up * Speed;
		}
	
		void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Asteroid")
			{
				Destroy(gameObject);
			}		
		}
	}
}
