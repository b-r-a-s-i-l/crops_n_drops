using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Scriptables.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace CropsNDrops.Scripts.Inventory
{
	public class Item : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private GameObject _selector = default;
		[SerializeField] private Image _image = default;
		[SerializeField] private Animator _animator;
		
		[Header("Informations")]
		[SerializeField] private ItemType _itemType = default;
		[SerializeField] private bool _canDrop = default;
		public virtual void Initialize(ItemSettings settings) { }

		public void ExecuteAnimationAndDestroy()
		{
			//_animator.enabled = true;
			//_animator.SetBool("Drop", true);
			Destroy(gameObject, .1f);
		}

		public bool ActiveSelector
		{
			get { return _canDrop; }
			set
			{
				_canDrop = value;
				_selector.SetActive(_canDrop);
			}
		}

		protected Image Image
		{
			get { return _image; }
		}

		protected Animator Animator
		{
			get { return _animator; }
		}

		protected ItemType ItemType
		{
			set { _itemType = value; }
		}
	}
}