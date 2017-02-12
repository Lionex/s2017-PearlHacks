using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject spawnedObject;

	public Vector3 spawnValues;  // The position of the spawner
	public float spawnXRange;    // The range of values X that objects can spawn in

	public float spawnWait;
	public float startWait;
	public float timeVariance;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}

	// Update is called once per frame
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);

		for (int i = 0; i < 100; i++) {
			Vector3 spawnPosition = new Vector3 (spawnValues.x + Random.Range(-spawnXRange,spawnXRange),spawnValues.y,spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Debug.Log("Spawn Object" + spawnedObject);
			Instantiate(spawnedObject, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range(timeVariance , spawnWait));
		}
	}
}
