using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowableCamera : MonoBehaviour
{
	[Header("Camera properties")]
    [SerializeField] private Transform _targetTransform;
	[SerializeField] private Vector3 _offset = new Vector3(0, 7, -7);
	[SerializeField] private float _speed = 2f;
	
	[Header("Obstacles properies")]
	[SerializeField] private LayerMask _masks;

	private List<ObstacleSetMaterial> _obstacles;

	private void Start()
	{
		_obstacles = new List<ObstacleSetMaterial>();
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

				if (obstacle.TryGetComponent<ObstacleSetMaterial>(out ObstacleSetMaterial obstacleSetMaterial))
				{
					_obstacles.Add(obstacleSetMaterial);
					obstacleSetMaterial.SetReplacementMaterial();
				}				
			}
		}
		else
		{
			if (_obstacles.Count == 0) return;

			foreach(ObstacleSetMaterial obstacle in _obstacles)
				obstacle.ResetMaterial();

			_obstacles.Clear();
		}
	}
}
