using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerController : MonoBehaviour
	{
		public GameObject[] Weapons;
		public GunModel GunModel;
		
		private Rigidbody _rbPlayer;
		private GameObject _firstGun;

		private GunModel[] _gunModels;
		
		void Start ()
		{
			_rbPlayer = GetComponent<Rigidbody>();
			_firstGun = GameObject.FindWithTag("FirstGun");
		}
	
		void Update () {
			
		}

		void FixedUpdate()
		{
			var inputFirstPlayer = Input.GetAxis("Horizontal");
			_firstGun.transform.rotation *= Quaternion.Euler(0f, 0f, inputFirstPlayer*Time.deltaTime);
		}
	}
}
