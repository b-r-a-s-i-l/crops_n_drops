using UnityEngine;

namespace CropsNDrops.Scripts.Inventory
{
	public class Slot : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private ItemBox itemBox = default;
		
		public delegate void SlotEvent(Slot slot);
		public event SlotEvent OnPutItem;

		private void Update()
		{
			if (DontHaveItem)
			{
				PutItem();
			}
		}

		public ItemBox ItemBox
		{
			set
			{
				itemBox = value;
			}
		}

		public bool DontHaveItem
		{
			get
			{
				return itemBox is null;
			}
		}

		protected virtual void PutItem()
		{
			OnPutItem?.Invoke(this);
		}
	}
}