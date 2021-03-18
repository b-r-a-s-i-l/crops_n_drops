using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Inventory;
using CropsNDrops.Scripts.Scriptables.Plants;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden.Plants
{
	public class CropPlant: GardenPlant
	{
		[SerializeField] private PlantStage _actualsStage = default;
		[SerializeField] private ElementType _nextStageRequeriment = default;
		[SerializeField] private CropLevelSettings[] _levelSettings = default;
		
		public override void Initialize(PlantDisplay display)
		{
			Display = display;
			
			if (Display is CropPlantDisplay cropPlantDisplay)
			{
				_levelSettings = cropPlantDisplay.cropLevelSettings;
				transform.localPosition = Vector3.zero;
				SetLevel(cropPlantDisplay.startLevel);
			}
			else
			{
				Destroy(gameObject);
			}
		}

		public override void DropOnMe(ElementItem elementItem)
		{
			ElementType elementType = elementItem.ElementType;
			ApllyItemToGrow(elementType);
			elementItem.ExecuteAnimationAndDestroy();
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
				}
			}
		}
		
		private void ApllyItemToGrow(ElementType elementTypeOfItem)
		{
			foreach (CropLevelSettings levelSetting in _levelSettings)
			{
				if (_actualsStage == levelSetting.stage)
				{
					if (elementTypeOfItem == _nextStageRequeriment)
					{
						SetLevel(_actualsStage + 1);
					}
				}
			}
		}

		public void TakeTheBasket()
		{
			Destroy(gameObject);
		}
	}
}