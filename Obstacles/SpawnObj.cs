using UnityEngine;
using System.Collections;

public class SpawnObj : MonoBehaviour
{
	[SerializeField]
	private bool timer = true;//time between spawns
	[SerializeField]
	private float spawnTime;//time between spawns
	[SerializeField]
	private float spawnDelay; //time for spawntime to start
	[SerializeField]
	private GameObject[] obstacle;
	[SerializeField]
	private GameObject spawnPoint;
	private GameObject _world;

	void Start ()
	{
        _world = GameObject.Find("World");

        // Call spawn repeatitly when timer is over
        if (timer)InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}

	//public void Spawn (GameObject _spawnPoint)
	void Spawn ()
	{
		int obstacleIndex = Random.Range(0, obstacle.Length);
		var Projectile = Instantiate (obstacle[obstacleIndex], spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
		Projectile.transform.parent = _world.gameObject.transform;

	}
}