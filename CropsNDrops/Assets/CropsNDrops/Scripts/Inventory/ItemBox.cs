using System;
using System.Collections;
using CropsNDrops.Scripts.Tools;
using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CropsNDrops.Scripts.Inventory
{
	public class ItemBox : MonoBehaviour
	{
		[SerializeField] private Transform _parent = default;
		[SerializeField] private Transform[] _boxSlots = default;
		[SerializeField] private Item[] _items = default;
		[SerializeField] private bool _isCaught = default;
		[SerializeField] private StudioEventEmitter _emitter = default;
		private void Update()
		{
			if (!_isCaught)
			{
				transform.position = Utils.Centralize(_parent.position, transform.position);
			}
		}

		private void OnDestroy()
		{
			Slot slot = _parent.GetComponent<Slot>();
			slot.ItemBox = null;
		}

		public IEnumerator ScaleItemBox(float scale)
		{
			Vector3 scaleUpdate = new Vector2(scale,scale);
			
			while (transform.localScale != scaleUpdate)
			{
				transform.localScale = Vector3.Lerp(transform.localScale, scaleUpdate, 60 * Time.deltaTime);
				yield return new WaitForEndOfFrame();
			}
		}
		
		public void DesactiveAllSelector()
		{
			foreach (Item item in _items)
			{
				item.ActiveSelector = false;
			}
		}

		public Item[] Items
		{
			get { return _items; }
		}
		
		public Transform[] BoxSlots
		{
			get { return _boxSlots; }
		}

		public bool AllItemsCanDrop
		{
			get
			{
				int count = 0;
				foreach (Item item in _items)
				{
					if (item.ActiveSelector)
					{
						count++;
					}
				}

				return count == _items.Length;
			}
		}

		public Transform Parent
		{
			get { return _parent; }
			set { _parent = value; }
		}
		
		public StudioEventEmitter Emitter
		{
			get { return _emitter; }
		}

		public bool SetIsCaught
		{
			set { _isCaught = value; }
		}
	}
}