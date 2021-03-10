using UnityEngine;

namespace CropsNDrops.Scripts.UI
{
	public class Slot : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private Item _item = default;

		public Item Item
		{
			get { return _item; }
			set { _item = value; }
		}

		public bool DontHaveItem
		{
			get { return _item == null; }
		}
		
	}
}