using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerController : MonoBehaviour
	{
		public GameObject[] Weapons;

		private float _nextFireFirst = 0.3f;
		private float _fireRateFirst = 0.7f;
		private float _nextFireSecond = 0.3f;
		private float _fireRateSecond = 0.4f;
		
		private Rigidbody _rbPlayer;
		private GameObject _firstGun;
		private GameObject _secondGun;
		
		private GameObject _shotSpawnFirst;
		private GameObject _shotSpawnSecond;

		private GunModel[] _gunModels;
		
		void Start ()
		{
			_rbPlayer = GetComponent<Rigidbody>();
			
			_firstGun = GameObject.FindWithTag("FirstGun");
			_secondGun = GameObject.FindWithTag("SecondGun");
			
			_shotSpawnFirst = GameObject.FindWithTag("ShotSpawnFirst");
			_shotSpawnSecond = GameObject.FindWithTag("ShotSpawnSecond");
		}
	
		void Update () {
			
		}

		void FixedUpdate()
		{
			// gun rotation  FIRST
			var speedRotFirst = 100;
			var inputFirstPlayer = Input.GetAxis("Horizontal");
			_firstGun.transform.rotation *= Quaternion.Euler(0f, 0f, inputFirstPlayer*Time.deltaTime*speedRotFirst);
			
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
			var speedRotSecond = 100;
			var inputSecondPlayer = Input.GetAxis("Horizontal11");
			_secondGun.transform.rotation *= Quaternion.Euler(0f, 0f, inputSecondPlayer*Time.deltaTime*speedRotSecond);
			
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
			
		}
	}
}
