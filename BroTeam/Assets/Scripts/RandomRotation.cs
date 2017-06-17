using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

	public float Tumble=1.5f;

	void Start ()
	{
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * Tumble;
	}
}
