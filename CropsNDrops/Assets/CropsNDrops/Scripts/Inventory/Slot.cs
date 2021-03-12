using System;
using UnityEngine;

namespace CropsNDrops.Scripts.Inventory
{
	public class Slot : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private Item _item = default;
		
		public delegate void SlotEvent(Slot slot);
		public event SlotEvent PutItem;

		private void Update()
		{
			if (DontHaveItem)
			{
				OnPutItem();
			}
		}

		public Item Item
		{
			get { return _item; }
			set { _item = value; }
		}

		private bool DontHaveItem
		{
			get { return _item is null; }
		}

		protected virtual void OnPutItem()
		{
			PutItem?.Invoke(this);
		}
	}
}