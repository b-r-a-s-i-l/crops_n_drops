using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Scriptables.Inventory;
using UnityEngine;

namespace CropsNDrops.Scripts.Inventory
{
	public class ElementItem : Item
	{
		[SerializeField] private ElementType elementType = default;
		
		public override void Initialize(ItemDisplay display)
		{
			if (display is ElementalItemDisplay elementalItemDisplay)
			{
				ElementType = elementalItemDisplay.element;
				
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
		
		public ElementType ElementType
		{
			get { return elementType; }
			set { elementType = value; }
		}
	}
}