using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Inventory.ItemDerivations;
using CropsNDrops.Scripts.Scriptables.Inventory;
using UnityEngine;

namespace CropsNDrops.Scripts.Inventory
{
	public class ItemGenerator : MonoBehaviour
	{
		[SerializeField] private Item[] _itemPrefabs = default;
		[SerializeField] private ItemBox[] _boxPrefabs = default;
		[SerializeField] private ItemSettings[] _itemDisplays = default;

		public ItemBox GerateItemBox(Slot slot)
		{
			ItemBox itemBox = Instantiate(RandomizeItemBox(), slot.transform);
			itemBox.Parent = slot.transform;

			for (int i = 0; i < itemBox.Items.Length; i++)
			{
				ItemSettings itemSettings = RandomizeItemDisplay();
				itemBox.Items[i] = GerateItem(itemSettings, itemBox.BoxSlots[i]);
			}

			return itemBox;
		}
		
		private Item GerateItem(ItemSettings itemSettings, Transform slotOfBox)
		{
			foreach (Item itemPrefab in _itemPrefabs)
			{
				switch (itemSettings)
				{
					case PlantItemSettings _ when itemPrefab is PlantItem:
					{
						itemSettings.ItemType = ItemType.PLANT;
						Item item = Instantiate(itemPrefab, slotOfBox);
						item.Initialize(itemSettings);
						return item;
					}
					case ElementalItemSettings _ when itemPrefab is ElementItem:
					{
						itemSettings.ItemType = ItemType.ELEMENTAL;
						Item item = Instantiate(itemPrefab, slotOfBox);
						item.Initialize(itemSettings);
						return item;
					}
				}
			}
			
			return null;
		}

		private ItemSettings RandomizeItemDisplay()
		{
			//Melhorar mais tarde

			int i = Random.Range(0, _itemDisplays.Length);

			return _itemDisplays[i];
		}
		
		private ItemBox RandomizeItemBox()
		{
			//Melhorar mais tarde

			int i = Random.Range(0, _boxPrefabs.Length);

			return _boxPrefabs[i];
		}
	}
}