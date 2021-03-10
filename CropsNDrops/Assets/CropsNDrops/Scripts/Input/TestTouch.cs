using System;
using UnityEngine;

namespace CropsNDrops.Scripts.Input
{
	public class TestTouch : MonoBehaviour
	{
		[SerializeField] private InputManager _inputManager = default;
		private Camera _camera = default;
		private void Awake()
		{
			_camera = Camera.main;
		}

		private void OnEnable()
		{
			_inputManager.OnStartTouch += Move;
			_inputManager.OnDragTouch += DragTouch;
		}

		private void OnDisable()
		{
			_inputManager.OnEndTouch -= Move;
			_inputManager.OnDragTouch -= DragTouch;
		}

		private void Move(Vector2 screenPosition)
		{
			Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, _camera.nearClipPlane);
			Vector3 wordlCoordinates = _camera.ScreenToWorldPoint(screenCoordinates);
			wordlCoordinates.z = 0;
			transform.position = wordlCoordinates;
		}

		private void DragTouch(Vector2 screenPosition)
		{
			Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, _camera.nearClipPlane);
			Vector3 wordlCoordinates = _camera.ScreenToWorldPoint(screenCoordinates);
			wordlCoordinates.z = 0;
			transform.position = wordlCoordinates;
		}
	}
}