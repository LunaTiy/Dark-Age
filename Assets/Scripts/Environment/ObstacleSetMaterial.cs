using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSetMaterial : MonoBehaviour
{
    [SerializeField] private Material _replacementMaterial;

	private Renderer _renderer;
	private Material _baseMaterial;

	private void Start()
	{
		_renderer = GetComponent<Renderer>();
		_baseMaterial = _renderer.material;
	}

	public void SetReplacementMaterial()
	{
		_renderer.material = _replacementMaterial;
	}

	public void ResetMaterial()
	{
		_renderer.material = _baseMaterial;
	}
}
