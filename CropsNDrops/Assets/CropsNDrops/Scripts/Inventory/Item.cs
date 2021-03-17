using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Scriptables.Inventory;
using CropsNDrops.Scripts.Tools;
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
		[SerializeField] private Transform _parent = default;
		[SerializeField] private ItemType _type = default;
		[SerializeField] private bool _isCaught = default;

		private void Update()
		{
			if (!_isCaught)
			{
				transform.position = Utils.Centralize(_parent.position, transform.position);
			}
		}
		
		public virtual void Initialize(ItemDisplay display) { }

		public void ExecuteAnimationAndDestroy()
		{
			_isCaught = true;
			_animator.SetTrigger("Drop");
			Destroy(gameObject, .5f);
		}

		public bool ActiveSelector
		{
			set { _selector.SetActive((value)); }
		}
		
		public Image Image
		{
			get { return _image; }
			set { _image = value; }
		}

		public Transform Parent
		{
			get { return _parent; }
			set { _parent = value; }
		}
		
		public ItemType Type
		{
			get { return _type; }
			set { _type = value; }
		}

		public bool IsCaught
		{
			set { _isCaught = value; }
		}
	}
}