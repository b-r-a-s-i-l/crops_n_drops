using CropsNDrops.Scripts.Enum;
using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Inventory
{
	[CreateAssetMenu(fileName = "New Elemental", menuName = "Elemental Item")]
	public class ElementalItemDisplay : ItemDisplay
	{
		public ElementType element = default;
	}
}