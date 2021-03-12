using CropsNDrops.Scripts.Scriptables.Garden;
using CropsNDrops.Scripts.Scriptables.Inventory;
using CropsNDrops.Scripts.Scriptables.Inventory.CropsNDrops.Scripts.Scriptables;
using UnityEngine;

namespace CropsNDrops.Scripts.Inventory
{
	public class PlantItem : Item
	{
		[SerializeField] private PlantDisplay _plantDisplay = default;
		
		public override void Initialize(ItemDisplay display)
		{
			if (display)
			{
				PlantItemDisplay tItemDisplay = display as PlantItemDisplay;
				
				name = display.name;
				PlantDisplay = tItemDisplay.plantDisplay;
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

		public PlantDisplay PlantDisplay
		{
			get { return _plantDisplay; }
			set { _plantDisplay = value; }
		}
	}
}