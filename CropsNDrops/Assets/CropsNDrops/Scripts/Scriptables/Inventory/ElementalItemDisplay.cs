using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Scriptables.Inventory.CropsNDrops.Scripts.Scriptables;
using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Inventory
{
	[CreateAssetMenu(fileName = "New Elemental", menuName = "Elemental Item")]
	public class ElementalItemDisplay : ItemDisplay
	{
		public ElementalType element = default;
	}
}