using System;
using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Inventory;
using CropsNDrops.Scripts.Inventory.ItemDerivations;
using CropsNDrops.Scripts.Scriptables.Plants;
using FMODUnity;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden.Plants
{
	public class CropPlant: GardenPlant
	{
		[SerializeField] private PlantStage _actualsStage = default;
		[SerializeField] private ElementType _nextStageRequeriment = default;
		[SerializeField] private int _score = default;
		[SerializeField] private CropLevelSettings[] _levelSettings = default;
		[SerializeField] private SpriteRenderer _requerimentRenderer = default;
		[SerializeField] private Sprite[] _requirementSprites = default;
		[SerializeField] private StudioEventEmitter _emitter = default;
		public override void Initialize(PlantSettings settings)
		{
			Settings = settings;
			
			if (Settings is CropPlantSettings cropPlantDisplay)
			{
				_score = cropPlantDisplay.score;
				_levelSettings = cropPlantDisplay.cropLevelSettings;
				transform.localPosition = Vector3.zero;
				SetLevel(cropPlantDisplay.startLevel);
				SetRequerimentSprite(_nextStageRequeriment);
			}
			else
			{
				Destroy(gameObject);
			}
		}

		public override void DropOnMe(Item item)
		{
			switch (item)
			{
				case ElementItem elementItem:
				{
					ElementType elementType = elementItem.ElementType;
					ApllyItemToGrow(elementType);
					elementItem.ExecuteAnimationAndDestroy();
					ExecuteAnimation("Smoke");
					return;
				}
				case PlantItem plantItem:
				{
					Destroy(gameObject, .1f);
					plantItem.ExecuteAnimationAndDestroy();
					ExecuteAnimation("Smoke");
					return;
				}
			}
			
		}

		private void SetLevel(PlantStage stage)
		{
			foreach (CropLevelSettings levelSetting in _levelSettings)
			{
				if (stage == levelSetting.stage)
				{
					_actualsStage = levelSetting.stage;
					_nextStageRequeriment = levelSetting.nextStageRequeriment;
					Renderer.sprite = levelSetting.sprite;
					SetRequerimentSprite(_nextStageRequeriment);
				}
			}
		}
		
		private void ApllyItemToGrow(ElementType elementTypeOfItem)
		{
			foreach (CropLevelSettings levelSetting in _levelSettings)
			{
				if (_actualsStage == levelSetting.stage)
				{
					if (elementTypeOfItem != _nextStageRequeriment)
					{
						Destroy(gameObject, .1f);
						return;
					}
					
					SetLevel(_actualsStage + 1);
					return;
				}
			}
		}

		private void SetRequerimentSprite(ElementType elementType)
		{
			switch (elementType)
			{
				case ElementType.WATER:
				{
					_requerimentRenderer.sprite = _requirementSprites[0];
					return;
				}
				case ElementType.SUNSHINE:
				{
					_requerimentRenderer.sprite = _requirementSprites[1];
					return;
				}
				case ElementType.NONE:
				{
					_requerimentRenderer.sprite = null;
					return;
				}
			}
		}

		public StudioEventEmitter Emitter
		{
			get { return _emitter; }
		}
		
		public PlantStage ActualsStage
		{
			get { return _actualsStage; }
		}
		public int Score
		{
			get { return _score; }
		}
	}
}