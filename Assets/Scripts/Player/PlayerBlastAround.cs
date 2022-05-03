using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBlastAround : MonoBehaviour
{
	[SerializeField] private UnityEvent<float> _blastedCooldown;
	[SerializeField] private UnityEvent _blasted;

	public int manaForCast = 10;
	public float timeBtwBlast = 8f;
    
	private float remainingTime;
	private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		BlastLogic();
	}

	private void BlastLogic()
	{
		if (Input.GetKeyDown(KeyCode.F))
			Blast();

		BlastCooldown();
	}

	private void BlastCooldown()
	{
		if (remainingTime > 0)
			remainingTime -= Time.deltaTime;
		else if (remainingTime < 0)
			remainingTime = 0;
	}

	public void Blast()
	{
		if (remainingTime == 0)
		{
			_animator.SetTrigger("Blast");
			remainingTime = timeBtwBlast;

			_blasted?.Invoke();
			_blastedCooldown?.Invoke(timeBtwBlast);
		}
	}

	public void OnPlayerAttacked(float time)
	{
		remainingTime = time;
	}
}
