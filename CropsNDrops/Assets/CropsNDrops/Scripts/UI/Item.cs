using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Scriptables.Inventory.CropsNDrops.Scripts.Scriptables;
using CropsNDrops.Scripts.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace CropsNDrops.Scripts.UI
{
	public class Item : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private GameObject _selector = default;
		[SerializeField] private Image _image = default;

		[Header("Informations")]
		[SerializeField] private ItemDisplay _display = default;
		[SerializeField] private Transform _parent = default;
		[SerializeField] private ItemType _type = default;
		[SerializeField] private bool _isCaught = default;
		//[SerializeField] private ActionArea _area = default;

		private void Update()
		{
			if (!_isCaught)
			{
				transform.position = Utils.Centralize(_parent.position, transform.position);
			}
		}
		
		public void Initialize(ItemDisplay display)
		{
			_display = display;
			
			if (_display)
			{
				name = display.name;
				_parent = transform.parent;
				_image.sprite = _display.sprite;
				_type = _display.type;
				//_area = _display.area;
				_isCaught = false;
				transform.localPosition = Vector3.zero;
			}
			else
			{
				Destroy(gameObject);
			}
		}

		

		public bool IsCaught
		{
			set { _isCaught = value; }
		}

		public ItemType Type
		{
			get { return _type; }
		}

		public ItemDisplay Display
		{
			get { return _display; }
		}

		public bool ActiveSelector
		{
			set { _selector.SetActive((value)); }
		}
	}
}