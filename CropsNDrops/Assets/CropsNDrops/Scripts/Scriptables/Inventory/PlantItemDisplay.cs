using CropsNDrops.Scripts.Scriptables.Garden;
using CropsNDrops.Scripts.Scriptables.Inventory.CropsNDrops.Scripts.Scriptables;
using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Inventory
{
	[CreateAssetMenu(fileName = "New Seed", menuName = "Seed Item")]
	public class PlantItemDisplay : ItemDisplay
	{
		public PlantDisplay plantDisplay = default;
	}
}