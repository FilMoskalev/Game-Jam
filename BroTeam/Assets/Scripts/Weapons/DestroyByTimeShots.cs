using UnityEngine;

namespace Assets.Scripts.Weapons
{
	public class DestroyByTimeShots : MonoBehaviour
	{

		public float LifeTime;
	
		void Start () {
			Destroy(gameObject, LifeTime);
		}
	}
}
