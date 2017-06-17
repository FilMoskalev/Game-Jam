using UnityEngine;

namespace Assets.Scripts.Weapons
{
	public class BulletMover : MonoBehaviour {
		
		public float Speed = 25f;
		
		void Start ()
		{
			GetComponent<Rigidbody>().velocity = transform.up * Speed;
		}
	}
}
