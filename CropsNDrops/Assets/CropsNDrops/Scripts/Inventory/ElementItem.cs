using CropsNDrops.Scripts.Scriptables.Inventory.CropsNDrops.Scripts.Scriptables;
using UnityEngine;

namespace CropsNDrops.Scripts.Inventory
{
	public class ElementItem : Item
	{
		public override void Initialize(ItemDisplay display)
		{
			if (display)
			{
				name = display.name;
				Parent = transform.parent;
				Image.sprite = display.sprite;
				Type = display.Type;
				IsCaught = false;
				transform.localPosition = Vector3.zero;
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}