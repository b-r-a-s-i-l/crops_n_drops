using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Garden.Plants;
using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Plants
{
	[CreateAssetMenu(fileName = "New CropPlant", menuName = "Crop Plant")]
	public class CropPlantDisplay: PlantDisplay
	{
		public PlantStage startLevel = default;
		public CropLevelSettings[] cropLevelSettings = default;
	}
}