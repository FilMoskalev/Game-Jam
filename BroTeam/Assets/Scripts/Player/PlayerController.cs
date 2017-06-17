using UnityEngine;
using UnityEngine.UI;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		public GameObject[] Weapons;
		public float MaxSpeed=3;
		public Text PlayerHealth;
		public Text TimeLeftText;
		public float TimeLeft;
		private float _nextFire = 0.3f;
		
		private float _fireRateSecond = 0.4f;
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
		private float _armorTimeLeft;
		
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
			
			// guns models
			_gunModels = new[]
			{
				new GunModel{ SpeedRotation = 300, FireRate = .2f, TypeWeapon = 1, Force = 100f, ModeControl = -1}, 
				new GunModel{ SpeedRotation = 200, FireRate = 0.4f, TypeWeapon = 1, Force = 20f, ModeControl = 1}, 
				new GunModel{ SpeedRotation = 200, FireRate = 0.5f, TypeWeapon = 2, Force = 25f, ModeControl = 1} 
			};
			//ChangeTheRules();
		}

		void ChangeTheRules()
		{
			foreach (var model in _gunModels)
			{
				model.SpeedRotation = Random.Range(50, 400);
				model.FireRate = Random.Range(.2f, 1f);
				model.TypeWeapon = Random.Range(0, 3);
				model.Force = Random.Range(10f, 100f);
				model.ModeControl = Random.Range(0, 2) == 0 ? 1: -1;
			}
			Debug.Log("Set New Rules");
		}
		
		void Update()
		{
			if (_rbPlayer.velocity.magnitude > MaxSpeed)
			{
				_rbPlayer.velocity = _rbPlayer.velocity.normalized * MaxSpeed;
			}
			TimeLeft -= Time.deltaTime;
			if (TimeLeft < 0)
			{
				ChangeTheRules();
				TimeLeft = 30;
			}
			TimeLeftText.text = "Time Left : " + (int)TimeLeft;
			_armorTimeLeft -= Time.deltaTime;
		}

		void FixedUpdate()
		{
			// gun rotation  FIRST
			var speedRotFirst = _gunModels[0].SpeedRotation;
			var inputFirstPlayer = Input.GetAxis("Horizontal") * _gunModels[0].ModeControl;
			_firstGun.transform.rotation *= Quaternion.Euler(0f, 0f, inputFirstPlayer * Time.deltaTime * speedRotFirst);

			// fire FIRST
			if (Input.GetButton("Fire1") && Time.time > _nextFire)
			{
				_nextFire = Time.time + _gunModels[0].FireRate;
				var bulllet = Instantiate(Weapons[_gunModels[0].TypeWeapon], _shotSpawnFirst.transform.position, _shotSpawnFirst.transform.rotation);
				// add force on player
				var forcePowerFirst = _gunModels[0].Force;
				_rbPlayer.AddForce(new Vector3(_rbPlayer.position.x - _shotSpawnFirst.transform.position.x,
					                   _rbPlayer.position.y - _shotSpawnFirst.transform.position.y, 0f) * forcePowerFirst);
			}

			// gun rotation  SECOND
			var speedRotSecond = _gunModels[1].SpeedRotation;
			var inputSecondPlayer = Input.GetAxis("Horizontal11") * _gunModels[1].ModeControl;
			_secondGun.transform.rotation *= Quaternion.Euler(0f, 0f, inputSecondPlayer * Time.deltaTime * speedRotSecond);

			// fire SECOND
			if (Input.GetButton("Fire11") && Time.time > _nextFire)
			{
				_nextFire = Time.time + _gunModels[1].FireRate;
				var bulllet = Instantiate(Weapons[_gunModels[1].TypeWeapon], _shotSpawnSecond.transform.position, _shotSpawnSecond.transform.rotation);
				// add force on player
				var forcePowerSecond = _gunModels[1].Force;
				_rbPlayer.AddForce(new Vector3(_rbPlayer.position.x - _shotSpawnSecond.transform.position.x,
					                   _rbPlayer.position.y - _shotSpawnSecond.transform.position.y, 0f) * forcePowerSecond);
			}

			// gun rotation  third
			var speedRotthird = _gunModels[2].SpeedRotation;
			var inputThirdPlayer = Input.GetAxis("Horizontal22") * _gunModels[2].ModeControl;
			_thirdGun.transform.rotation *= Quaternion.Euler(0f, 0f, inputThirdPlayer * Time.deltaTime * speedRotthird);

			// fire THIRD
			if (Input.GetButton("Fire25") && Time.time > _nextFire)
			{
				_nextFire = Time.time + _gunModels[2].FireRate;
				var bulllet = Instantiate(Weapons[_gunModels[2].TypeWeapon], _shotSpawnThird.transform.position, _shotSpawnThird.transform.rotation);
				// add force on player
				var forcePowerThird = _gunModels[2].Force;
				_rbPlayer.AddForce(new Vector3(_rbPlayer.position.x - _shotSpawnThird.transform.position.x,
					                   _rbPlayer.position.y - _shotSpawnThird.transform.position.y, 0f) * forcePowerThird);
			}
		}

		void OnTriggerEnter(Collider other)
		{
			if (_armorTimeLeft < 0f)
			{
				//Debug.Log("Armor inactive");
				if (other.tag.Contains("BoltEnemy"))
				{
					Destroy(other.gameObject);
					_playerHealth -= 1;	
				}
				else
				{
					if (other.tag.Contains("Enemy"))
					{
						Destroy(other.gameObject);
						_playerHealth -= 5;				
					}
				}
			}
			
			// boosts
			if (other.tag.Contains("Armor"))
			{
				Debug.Log("Armor");
				Destroy(other.gameObject);
				_armorTimeLeft = 15;
			}
			
			if (other.tag.Contains("Medipack"))
			{
				Destroy(other.gameObject);
				_playerHealth += 15;
				if (_playerHealth > 100) _playerHealth = 100;
			}
			PlayerHealth.text = "Health : " + _playerHealth + "%";
		}
	}
}
