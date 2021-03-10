using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Garden
{
	[CreateAssetMenu(fileName = "New Plant", menuName = "Plant Object")]
	public class PlantDisplay : GardenObjectDisplay
	{
		public Sprite[] sprites = new Sprite[6];
		//public PlantType type  = default;
		//public GrowthStage stage  = default;
		//public int scoreToGive = default;
		//public int wateringByStage = default;
	}
}