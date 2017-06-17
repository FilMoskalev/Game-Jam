using UnityEngine;

namespace Weapons
{
	public class BulletController : MonoBehaviour {
		
		public float Speed = 25f;
		private GameController _gameController;
		
		void Start ()
		{
			GetComponent<Rigidbody>().velocity = transform.up * Speed;
			var gameControllerObject = GameObject.FindWithTag("GameController");
			if (gameControllerObject != null)
			{
				_gameController = gameControllerObject.GetComponent<GameController>();
			}
		}
				
		void OnTriggerEnter(Collider other)
		{
			if (other.tag.Contains("Enemy"))
			{
				Destroy(other.gameObject);
				_gameController.AddScore(other.tag);
			}
			Destroy(gameObject);
		}
	}
}
