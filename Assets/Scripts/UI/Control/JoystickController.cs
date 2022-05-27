using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	private Image _joystickBG;
	private Image _joystick;
	private Vector2 _inputVector;

	private void Start()
	{
		_joystickBG = GetComponent<Image>();
		_joystick = transform.GetChild(0).GetComponent<Image>();
	}

	public virtual void OnPointerDown(PointerEventData pointerEventData)
	{
		OnDrag(pointerEventData);
	}

	public virtual void OnPointerUp(PointerEventData pointerEventData)
	{
		_inputVector = Vector2.zero;
		_joystick.rectTransform.anchoredPosition = Vector2.zero;
	}

	public virtual void OnDrag(PointerEventData pointerEventData)
	{
		Vector2 position;

		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBG.rectTransform, pointerEventData.position, 
			pointerEventData.pressEventCamera, out position))
		{
			position.x = position.x / _joystickBG.rectTransform.sizeDelta.x;
			position.y = position.y / _joystickBG.rectTransform.sizeDelta.y;

			_inputVector = new Vector2(position.x * 2 - 0.1f, position.y * 2 - 0.1f);
			_inputVector = _inputVector.magnitude > 1f ? _inputVector.normalized : _inputVector;

			_joystick.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (_joystickBG.rectTransform.sizeDelta.x / 2),
				_inputVector.y * (_joystickBG.rectTransform.sizeDelta.y / 2));
		}
	}

	public float Horizontal()
	{
		if (_inputVector.x != 0) return _inputVector.x;
		else return Input.GetAxis("Horizontal");
	}

	public float Vertical()
	{
		if (_inputVector.y != 0) return _inputVector.y;
		else return Input.GetAxis("Vertical");
	}
}
