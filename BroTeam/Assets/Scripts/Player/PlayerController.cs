using UnityEngine;
using UnityEngine.UI;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		public GameObject[] Weapons;
		public float MaxSpeed=3;
		public Text PlayerHealth;
		
		private float _nextFireFirst = 0.3f;
		private float _fireRateFirst = 0.7f;
		private float _nextFireSecond = 0.3f;
		private float _fireRateSecond = 0.4f;
		private float _nextFireThird = 0.3f;
		private float _fireRateThird = 0.5f;

		private Rigidbody _rbPlayer;
		private GameObject _firstGun;
		private GameObject _secondGun;
		private GameObject _thirdGun;

		private GameObject _shotSpawnFirst;
		private GameObject _shotSpawnSecond;
		private GameObject _shotSpawnThird;

		private GunModel[] _gunModels;
		private GameController _gameController;
		private int _playerHealth=100;
		
		void Start()
		{
			_rbPlayer = GetComponent<Rigidbody>();

			_firstGun = GameObject.FindWithTag("FirstGun");
			_secondGun = GameObject.FindWithTag("SecondGun");
			_thirdGun = GameObject.FindWithTag("ThirdGun");

			_shotSpawnFirst = GameObject.FindWithTag("ShotSpawnFirst");
			_shotSpawnSecond = GameObject.FindWithTag("ShotSpawnSecond");
			_shotSpawnThird = GameObject.FindWithTag("ShotSpawnThird");
			
			var gameControllerObject = GameObject.FindWithTag("GameController");
			if (gameControllerObject != null)
			{
				_gameController = gameControllerObject.GetComponent<GameController>();
			}
		}

		void Update()
		{
			if (_rbPlayer.velocity.magnitude > MaxSpeed)
			{
				_rbPlayer.velocity = _rbPlayer.velocity.normalized * MaxSpeed;
			}
		}

		void FixedUpdate()
		{
			// gun rotation  FIRST
			var speedRotFirst = 200;
			var inputFirstPlayer = Input.GetAxis("Horizontal");
			_firstGun.transform.rotation *= Quaternion.Euler(0f, 0f, inputFirstPlayer * Time.deltaTime * speedRotFirst);

			// fire FIRST
			if (Input.GetButton("Fire1") && Time.time > _nextFireFirst)
			{
				_nextFireFirst = Time.time + _fireRateFirst;
				var bulllet = Instantiate(Weapons[1], _shotSpawnFirst.transform.position, _shotSpawnFirst.transform.rotation);
				// add force on player
				var forcePowerFirst = 30f;
				_rbPlayer.AddForce(new Vector3(_rbPlayer.position.x - _shotSpawnFirst.transform.position.x,
					                   _rbPlayer.position.y - _shotSpawnFirst.transform.position.y, 0f) * forcePowerFirst);
			}

			// gun rotation  SECOND
			var speedRotSecond = 200;
			var inputSecondPlayer = Input.GetAxis("Horizontal11");
			_secondGun.transform.rotation *= Quaternion.Euler(0f, 0f, inputSecondPlayer * Time.deltaTime * speedRotSecond);

			// fire SECOND
			if (Input.GetButton("Fire11") && Time.time > _nextFireSecond)
			{
				_nextFireSecond = Time.time + _fireRateSecond;
				var bulllet = Instantiate(Weapons[0], _shotSpawnSecond.transform.position, _shotSpawnSecond.transform.rotation);
				// add force on player
				var forcePowerSecond = 20f;
				_rbPlayer.AddForce(new Vector3(_rbPlayer.position.x - _shotSpawnSecond.transform.position.x,
					                   _rbPlayer.position.y - _shotSpawnSecond.transform.position.y, 0f) * forcePowerSecond);
			}

			// gun rotation  third
			var speedRotthird = 200;
			var inputThirdPlayer = Input.GetAxis("Horizontal22");
			_thirdGun.transform.rotation *= Quaternion.Euler(0f, 0f, inputThirdPlayer * Time.deltaTime * speedRotthird);

			// fire THIRD
			if (Input.GetButton("Fire25") && Time.time > _nextFireThird)
			{
				_nextFireThird = Time.time + _fireRateThird;
				var bulllet = Instantiate(Weapons[0], _shotSpawnThird.transform.position, _shotSpawnThird.transform.rotation);
				// add force on player
				var forcePowerThird = 25f;
				_rbPlayer.AddForce(new Vector3(_rbPlayer.position.x - _shotSpawnThird.transform.position.x,
					                   _rbPlayer.position.y - _shotSpawnThird.transform.position.y, 0f) * forcePowerThird);
			}
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.tag.Contains("Enemy"))
			{
				Destroy(other.gameObject);
				_playerHealth -= 5;				
			}
			PlayerHealth.text = "Health : " + _playerHealth + "%";
		}
	}
}
