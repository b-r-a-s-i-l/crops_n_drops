using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Plants
{
	[CreateAssetMenu(fileName = "New WeedPlant", menuName = "Weed Plant")]
	public class WeedPlantSettings: PlantSettings
	{
		public Sprite sprite = default;
	}
}