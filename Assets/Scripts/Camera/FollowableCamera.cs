using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowableCamera : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
	[SerializeField] private Vector3 _offset = new Vector3(0, 7, -7);
	[SerializeField] private float _speed = 2f;
	[Space]
	[SerializeField] private LayerMask _masks;

	private List<MeshRenderer> _obstacles;

	private void Start()
	{
		_obstacles = new List<MeshRenderer>();
	}

	private void Update()
	{
		FollowTarget();
		CheckObstacles();
	}

	private void FollowTarget()
	{
		Vector3 positionToFollow = _targetTransform.position + _offset;
		transform.position = Vector3.Lerp(transform.position, positionToFollow, _speed * Time.deltaTime);
	}

	private void CheckObstacles()
	{
		Ray ray = new Ray(_targetTransform.position, transform.position - _targetTransform.position);
		RaycastHit[] raycastHits = Physics.RaycastAll(ray, Vector3.Distance(transform.position, _targetTransform.position), _masks);

		if(raycastHits.Length > 0)
		{
			foreach(RaycastHit hit in raycastHits)
			{
				GameObject obstacle = hit.collider.gameObject;
				MeshRenderer obstacleMesh = obstacle.GetComponent<MeshRenderer>();

				_obstacles.Add(obstacleMesh);
				obstacleMesh.enabled = false;

				Debug.Log($"Raycast obstacle: {obstacle.name}");
			}
		}
		else
		{
			foreach (var obstacleMesh in _obstacles)
				obstacleMesh.enabled = true;

			_obstacles.Clear();
		}
	}
}
