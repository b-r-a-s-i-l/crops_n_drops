using CropsNDrops.Scripts.Enum;
using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Inventory
{
	public class ItemSettings : ScriptableObject
	{
		private ItemType _itemType = default;
		public Sprite sprite = default;
		public ItemType ItemType
		{
			get { return _itemType; }
			set { _itemType = value; }
		}
	}
}