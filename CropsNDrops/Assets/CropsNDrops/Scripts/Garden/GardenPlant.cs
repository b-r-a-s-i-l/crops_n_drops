using System;
using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Scriptables.Garden;
using CropsNDrops.Scripts.UI;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden
{
	public class GardenPlant : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private SpriteRenderer _renderer = default;
		[SerializeField] private Animator _fx = default;
		
		[Header("Informations")]
		[SerializeField] private PlantDisplay _display = default;
		[SerializeField] private PlantType _type = default;
		[SerializeField] protected PlantStage _stage = default;
		
		private Sprite[] _sprites = default;
		public void Initialize(PlantDisplay display)
		{
			_display = display;
			
			if (_display)
			{
				_type = _display.type;
				_stage = _display.stage;
				_sprites = _display.sprites;
				transform.localPosition = Vector3.zero;
				_renderer.sprite = _sprites[(int)_stage];
			}
			else
			{
				Destroy(gameObject);
			}
		}
		
		public void UpdateCondition(Item item)
		{
			switch (_type)
			{
				case PlantType.STRAWBERRY:
					//ApllyItemInCropPlant(item);
					return;
				case PlantType.WEEDPLANT:
					// ações referentes a weed
					return;
			}
		}

		public virtual void ApllyItemInCropPlant(Item item) { }
		
		private void Grow()
		{
			_stage += 1;
			_renderer.sprite = _sprites[(int)_stage];
		}
		
		public void TakeTheBasket()
		{
			Destroy(gameObject);
		}

		public PlantStage Stage
		{
			get { return _stage; }
		}
	}
}