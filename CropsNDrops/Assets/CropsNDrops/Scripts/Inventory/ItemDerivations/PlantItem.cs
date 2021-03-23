using CropsNDrops.Scripts.Scriptables.Inventory;
using CropsNDrops.Scripts.Scriptables.Plants;
using UnityEngine;

namespace CropsNDrops.Scripts.Inventory.ItemDerivations
{
	public class PlantItem : Item
	{
		[SerializeField] private PlantSettings plantSettings = default;
		public override void Initialize(ItemSettings settings)
		{
			if (settings is PlantItemSettings plantItemDisplay)
			{
				PlantSettings = plantItemDisplay.plantSettings;
				
				name = settings.name;
				transform.localPosition = Vector3.zero;
				Animator.enabled = false;
				//Parent = transform.parent; PEGAR DO ITEMBOX
				Image.sprite = settings.sprite;
				ItemType = settings.ItemType;
				//IsCaught = false; PEGAR DO ITEMBOX
			}
			else
			{
				Destroy(gameObject);
			}
		}

		public PlantSettings PlantSettings
		{
			get { return plantSettings; }
			private set { plantSettings = value; }
		}
	}
}