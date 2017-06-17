using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] Hazards;
	public Vector3 SpawnValues;
	public int ForcePower;
	public Text ScoreText;
	public int HazardCount;
	public int SpawnWait;

	private int _score;

	private PlayerController _player;

	void Start()
	{
		var playerObject = GameObject.FindWithTag("Player");
		if (playerObject != null)
		{
			_player = playerObject.GetComponent<PlayerController>();
		}

		StartCoroutine(SpawnWaves());
	}

	IEnumerator SpawnWaves()
	{
		while (true)
		{
			for (int i = 0; i < HazardCount; i++)
			{
				var randomValue = Random.Range(0, 10);
				var playerRbPosition = _player.GetComponent<Rigidbody>().position;
				if (randomValue > 5) randomValue = 1;
				else randomValue = -1;
				//Debug.Log(randomValue);
				Vector3 spawnPosition = new Vector3(
					playerRbPosition.x + Random.Range(-SpawnValues.x, SpawnValues.x),
					randomValue *SpawnValues.y + playerRbPosition.y,
					SpawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				var curHazard = Hazards[Random.Range(0, Hazards.Length)];
				var hazard = Instantiate(curHazard, spawnPosition, spawnRotation);
				hazard.transform.LookAt(playerRbPosition);
				hazard.GetComponent<Rigidbody>().AddForce(new Vector3(
					                                          playerRbPosition.x - spawnPosition.x,
					                                          playerRbPosition.y - spawnPosition.y, 0) *
				                                          ForcePower);
				yield return new WaitForSeconds(SpawnWait);
			}
			yield return new WaitForSeconds(SpawnWait);
		}
	}
		
	public void AddScore(string nameObject)
	{
		if (nameObject == "Enemy2")
		{
			_score += 10;
		}
		else
		{
			_score += 5;
		}
		ScoreText.text = "Score : " + _score;
	}
}
