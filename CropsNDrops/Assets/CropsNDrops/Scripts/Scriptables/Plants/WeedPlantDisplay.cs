using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Plants
{
	[CreateAssetMenu(fileName = "New WeedPlant", menuName = "Weed Plant")]
	public class WeedPlantDisplay: PlantDisplay
	{
		public Sprite sprite = default;
	}
}