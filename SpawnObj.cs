using UnityEngine;
using System.Collections;

public class SpawnObj : MonoBehaviour
{
	[SerializeField]
	private bool timer = true;//time between spawns
	[SerializeField]
	private float spawnTime = 3f;//time between spawns
	[SerializeField]
	private float spawnDelay = 3f; //time for spawntime to start
	[SerializeField]
	private GameObject[] obstacle;
	[SerializeField]
	private GameObject spawnPoint;
	private GameObject _world;

	void Start ()
	{
		// Call spawn repeatitly when timer is over
		if(timer)InvokeRepeating("Spawn", spawnDelay, spawnTime);
		_world = GameObject.Find ("World");
	}

	//public void Spawn (GameObject _spawnPoint)
	void Spawn ()
	{
		int obstacleIndex = Random.Range(0, obstacle.Length);
		var Projectile = Instantiate (obstacle[obstacleIndex], spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
		Projectile.transform.parent = _world.gameObject.transform;
	}
}