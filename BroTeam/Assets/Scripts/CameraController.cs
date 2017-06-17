using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform Player;
	private Transform _thisTransform;
	public float Smoothrate = 0.5f;
	public int Multiply;
	private Vector2 _velocity;

	void Start ()
	{
		_thisTransform = transform;
		_velocity = new Vector2(0.5f, 0.5f);
	}

	void FixedUpdate () 
	{
		Vector2 newPos2D = Vector2.zero;
		newPos2D.x = Mathf.SmoothDamp(_thisTransform.position.x, Player.position.x, ref _velocity.x, Smoothrate);

		newPos2D.y = Mathf.SmoothDamp(_thisTransform.position.y,Player.position.y, ref _velocity.y, Smoothrate);

		Vector3 newPos = new Vector3(newPos2D.x, newPos2D.y, transform.position.z);

		transform.position = Vector3.Slerp(transform.position, newPos, Time.time * Multiply);
		transform.rotation = Player.rotation;
	}
}