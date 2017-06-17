using UnityEngine;

namespace Assets.Scripts.Weapons
{
	public class BoltMover : MonoBehaviour {

		public float Speed = 25f;
		
		void Start ()
		{
			GetComponent<Rigidbody>().velocity = transform.up * Speed;
		}
	}
}
