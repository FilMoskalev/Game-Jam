using UnityEngine;

namespace Weapons
{
	public class RayShootController : MonoBehaviour {

		public float Speed = 200f;
		private GameController _gameController;
		
		void Start ()
		{
			GetComponent<Rigidbody>().velocity = transform.up * Speed;
			var gameControllerObject = GameObject.FindWithTag("GameController");
			if (gameControllerObject != null)
			{
				_gameController = gameControllerObject.GetComponent<GameController>();
			}
			Destroy(gameObject, 5f);
		}
				
		void OnTriggerEnter(Collider other)
		{
			if (other.tag.Contains("Enemy"))
			{
				Destroy(other.gameObject);
				_gameController.AddScore(other.tag);
			}
		}
	}
}
