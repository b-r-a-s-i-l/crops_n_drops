using CropsNDrops.Scripts.Enum;
using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Inventory
{
	namespace CropsNDrops.Scripts.Scriptables
	{
		public class ItemDisplay : ScriptableObject
		{
			private ItemType _type = default;
			public Sprite sprite = default;
			public ItemType Type
			{
				get { return _type; }
				set { _type = value; }
			}
		}
	}
}