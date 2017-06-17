using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerController : MonoBehaviour
	{
		public GameObject[] Weapons;

		public float _nextFire = 0.3f;
		public float _fireRate = 0.5f;
		
		private Rigidbody _rbPlayer;
		private GameObject _firstGun;
		private GameObject _shotSpawnFirst;

		private GunModel[] _gunModels;
		
		void Start ()
		{
			_rbPlayer = GetComponent<Rigidbody>();
			_firstGun = GameObject.FindWithTag("FirstGun");
			_shotSpawnFirst = GameObject.FindWithTag("ShotSpawnFirst");
		}
	
		void Update () {
			
		}

		void FixedUpdate()
		{
			// gun rotation  FIRST
			var speedRot = 100;
			var inputFirstPlayer = Input.GetAxis("Horizontal");
			_firstGun.transform.rotation *= Quaternion.Euler(0f, 0f, inputFirstPlayer*Time.deltaTime*speedRot);
			
			// fire FIRST
			if (Input.GetButton("Fire1") && Time.time > _nextFire)
			{
				_nextFire = Time.time + _fireRate;
				var bulllet = Instantiate(Weapons[1], _shotSpawnFirst.transform.position, _shotSpawnFirst.transform.rotation);				
				// add force on player
				var forcePower = 30f;
				_rbPlayer.AddForce(new Vector3(_rbPlayer.position.x - _shotSpawnFirst.transform.position.x,
					_rbPlayer.position.y - _shotSpawnFirst.transform.position.y, 0f) * forcePower);
			}
			
			
			
			
		}
	}
}
