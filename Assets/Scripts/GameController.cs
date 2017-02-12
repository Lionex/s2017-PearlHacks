using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject bubble;	
	public Vector3 spawnValues;
	public float spawnJitter;
	public float spawnWait;
	public float startWait;
	public float timeVariance;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}

	void Update () {
		if (false) { // HACK: need the couroutine to end only under a condition to be determined.
			StopCoroutine (SpawnWaves ());
		}
	}

	// Update is called once per frame
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);
		while (true) {
			Vector3 spawnPosition = new Vector3 (spawnValues.x + Random.Range(-spawnJitter,spawnJitter),spawnValues.y,spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Debug.Log("Create bubble.");
			Instantiate(bubble, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait + Random.Range(-spawnJitter, spawnJitter));
		}
	}
}
