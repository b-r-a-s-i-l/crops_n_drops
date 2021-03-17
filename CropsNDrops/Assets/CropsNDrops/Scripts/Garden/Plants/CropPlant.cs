using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Scriptables.Plants;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden.Plants
{
	public class CropPlant: GardenPlant
	{
		[SerializeField] protected PlantStage _actualsStage = default;
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

		private void SetLevel(PlantStage stage)
		{
			foreach (CropLevelSettings levelSetting in _levelSettings)
			{
				if (stage == levelSetting.stage)
				{
					Renderer.sprite = levelSetting.sprite;
				}
			}
		}
		
		private void Grow()
		{
			//
		}

		public void TakeTheBasket()
		{
			Destroy(gameObject);
		}
	}
}