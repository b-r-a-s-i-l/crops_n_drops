using CropsNDrops.Scripts.Enum;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden.Plants
{
	[System.Serializable]
	public class CropLevelSettings
	{
		public Sprite sprite = default;
		public PlantStage stage = default;
		public ElementType nextStageRequeriment = default;
	}
}