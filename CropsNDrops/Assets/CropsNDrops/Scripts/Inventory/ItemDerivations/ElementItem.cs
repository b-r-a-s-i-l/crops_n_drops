using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Scriptables.Inventory;
using UnityEngine;

namespace CropsNDrops.Scripts.Inventory.ItemDerivations
{
	public class ElementItem : Item
	{
		[SerializeField] private ElementType elementType = default;
		
		public override void Initialize(ItemSettings settings)
		{
			if (settings is ElementalItemSettings elementalItemDisplay)
			{
				ElementType = elementalItemDisplay.element;
				
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
		
		public ElementType ElementType
		{
			get { return elementType; }
			private set { elementType = value; }
		}
	}
}