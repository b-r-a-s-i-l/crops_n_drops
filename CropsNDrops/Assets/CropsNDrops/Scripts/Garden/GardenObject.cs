using System;
using CropsNDrops.Scripts.Scriptables.Garden;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CropsNDrops.Scripts.Garden
{
	public class GardenObject : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private SpriteRenderer _renderer = default;
		
		[Header("Informations")]
		[SerializeField] private PlantDisplay _display = default;

		private Sprite[] _sprites = default;
		public void Initialize(PlantDisplay display)
		{
			_display = display;
			
			if (_display)
			{
				_sprites = _display.sprites;
				transform.localPosition = Vector3.zero;
				_renderer.sprite = _sprites[0];
			}
			else
			{
				Destroy(gameObject);
			}
		}
		
		public void TakeTheBasket()
		{
			Destroy(gameObject);
		}
	}
}