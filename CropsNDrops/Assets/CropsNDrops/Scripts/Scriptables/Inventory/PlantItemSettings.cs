using CropsNDrops.Scripts.Scriptables.Plants;
using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Inventory
{
	[CreateAssetMenu(fileName = "New Seed", menuName = "Seed Item")]
	public class PlantItemSettings : ItemSettings
	{
		public PlantSettings plantSettings = default;
	}
}