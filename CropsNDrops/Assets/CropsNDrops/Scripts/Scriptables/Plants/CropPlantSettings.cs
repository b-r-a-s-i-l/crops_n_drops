using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Garden.Plants;
using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Plants
{
	[CreateAssetMenu(fileName = "New CropPlant", menuName = "Crop Plant")]
	public class CropPlantSettings: PlantSettings
	{
		public PlantStage startLevel = default;
		public int score = default;
		public CropLevelSettings[] cropLevelSettings = default;
	}
}