using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject spawnedObject;

	public Vector3 initialForce;
	public Vector3 initialForceVariance;

	public Vector3 spawnPosition;  // The position of the spawner
	public Vector3 spawnRange;    // The range of values X that objects can spawn in

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

			Vector3 location = SpawnRange(spawnPosition,spawnRange);
			Quaternion spawnRotation = Quaternion.identity;
			GameObject spawnedClone = Instantiate<GameObject>(spawnedObject, location, spawnRotation);
			spawnedClone.GetComponent<Rigidbody>().AddForce(SpawnRange(initialForce,initialForceVariance));

			Debug.Log("Spawn Object" + spawnedObject);

			yield return new WaitForSeconds (Random.Range(spawnWait - timeVariance , spawnWait));
		}
	}

	private Vector3 SpawnRange (Vector3 Base, Vector3 Variance) {
		return new Vector3
			( Base.x + Random.Range(-Variance.x, Variance.x)
			, Base.y + Random.Range(-Variance.y, Variance.y)
			, Base.z + Random.Range(-Variance.z, Variance.z)
			);
	}
}