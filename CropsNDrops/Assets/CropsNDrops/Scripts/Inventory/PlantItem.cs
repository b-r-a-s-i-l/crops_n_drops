using CropsNDrops.Scripts.Scriptables.Inventory;
using CropsNDrops.Scripts.Scriptables.Plants;
using UnityEngine;

namespace CropsNDrops.Scripts.Inventory
{
	public class PlantItem : Item
	{
		[SerializeField] private PlantDisplay _plantDisplay = default;
		public override void Initialize(ItemDisplay display)
		{
			if (display is PlantItemDisplay plantItemDisplay)
			{
				PlantDisplay = plantItemDisplay.plantDisplay;
				
				name = display.name;
				transform.localPosition = Vector3.zero;
				Animator.enabled = false;
				Parent = transform.parent;
				Image.sprite = display.sprite;
				Type = display.Type;
				IsCaught = false;
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