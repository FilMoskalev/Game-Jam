using UnityEngine;

namespace Enemies
{
	public class DestroyByTimeEnemies : MonoBehaviour {

		public float LifeTime;
	
		void Start () {
			Destroy(gameObject, LifeTime);
		}
	}
}
