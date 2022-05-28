using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;
	[SerializeField] private int _maxSpawnerItems;

	private void Start()
	{
		StartCoroutine(Spawn());
	}

	private IEnumerator Spawn()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));

			if (transform.childCount <= _maxSpawnerItems)
				Instantiate(_prefab, transform);
		}
	}
}
