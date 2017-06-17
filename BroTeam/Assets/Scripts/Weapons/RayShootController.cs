using UnityEngine;

namespace Weapons
{
	public class RayShootController : MonoBehaviour {

		public float Speed = 200f;
		private GameController _gameController;
		public  GameObject MedicalPack;
		public  GameObject Armor;
		
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
			if (other.tag.Contains("Enemy") && !other.tag.Contains("Bolt"))
			{			
				Destroy(other.gameObject);
				_gameController.AddScore(other.tag);
				if (Random.Range(1, 10) > 7)
				{
					Instantiate(MedicalPack, transform.position, transform.rotation);
				} else if (Random.Range(1, 10) > 7)
				{
					Instantiate(Armor, transform.position, transform.rotation);
				}
			}
		}
	}
}
