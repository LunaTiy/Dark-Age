using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBlastAround : MonoBehaviour
{
	[SerializeField] private UnityEvent _blasted = new UnityEvent();
	[HideInInspector] public bool isBlast;

	public float timeBtwBlast = 15f;
    public float remainingTime;

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
		{
			remainingTime = 0;
			isBlast = false;
		}
	}

	public void Blast()
	{
		if (remainingTime == 0)
		{
			_animator.SetTrigger("Blast");
			remainingTime = timeBtwBlast;
			isBlast = true;

			_blasted.Invoke();
		}
	}

	public void OnPlayerAttacked()
	{
		remainingTime = 1f;
	}
}
