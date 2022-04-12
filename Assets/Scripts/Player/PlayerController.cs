using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _angularSpeed;
	[SerializeField] private float _jumpForce;
	[SerializeField] private float _gravityForce;
	[Space]
	[SerializeField] private JoystickController _joystick;

	private CharacterController _controller;
    private Animator _animator;

	private Vector3 _moveVector;
	private float _gravity;

	private bool _canRun;
	private float _elapsedTime;

	private void Start()
	{
		_controller = GetComponent<CharacterController>();
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		Movement();
		Gravity();
	}

	private void Movement()
	{
		if (_controller.isGrounded)
		{
			_moveVector = Vector3.zero;
			_moveVector.x = _joystick.Horizontal();
			_moveVector.z = _joystick.Vertical();

			_animator.SetFloat("Speed", (Mathf.Abs(_moveVector.x) + Mathf.Abs(_moveVector.z)) / 2);

			_moveVector *= _movementSpeed;

			Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, _angularSpeed * Time.deltaTime, 0f);
			transform.rotation = Quaternion.LookRotation(direct);
		}
		else
		{
			_animator.SetFloat("Speed", 0.1f);
		}

		_moveVector.y = _gravity;

		if (_elapsedTime > 0)
		{
			_elapsedTime -= Time.deltaTime;
			_moveVector = Vector3.zero;
		}
			
		_controller.Move(_moveVector * Time.deltaTime);
	}

	private void Gravity()
	{
		if (!_controller.isGrounded) _gravity -= _gravityForce * Time.deltaTime;
		else _gravity = -1f;

		if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded) _gravity = _jumpForce;
	}

	public void OnBlasted(float time)
	{
		_elapsedTime = time;
	}
}
