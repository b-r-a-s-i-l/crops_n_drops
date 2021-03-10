using System;
using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Garden;
using CropsNDrops.Scripts.Input;
using CropsNDrops.Scripts.Scriptables.Inventory;
using CropsNDrops.Scripts.Scriptables.Inventory.CropsNDrops.Scripts.Scriptables;
using CropsNDrops.Scripts.Tools;
using CropsNDrops.Scripts.UI;
using UnityEngine;

namespace CropsNDrops.Scripts.Player
{
	public class Player : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private InputManager _input = default;
		
		[Header("Informations")]
		[SerializeField] private GameObject _caughtObject = default;
		[SerializeField] private Item _caughtObjectAsItem = default;
		private void Awake()
		{
			_input.OnStartTouch += Catch;
			_input.OnDragTouch += Drag;
			_input.OnEndTouch += Drop;
		}

		private void OnDestroy()
		{
			_input.OnStartTouch -= Catch;
			_input.OnDragTouch -= Drag;
			_input.OnEndTouch -= Drop;
		}

		private void Catch(Vector2 eventPosition)
		{
			GameObject hit = Utils.GetRaycastHitObject(eventData: eventPosition, true);

			if (!hit)
			{
				hit = Utils.GetRaycastHitObject(eventData: eventPosition);
			}
			
			if (!hit)
			{
				return;
			}

			_caughtObject = hit;

			LayerMask layer = _caughtObject.layer;
				
			switch (layer)
			{
				case 8: //Item
				{
					SetAsItem();
					return;
				}
				case 10: //GardenObject
				{
					SetAsGardenObject();
					return;
				}
			}
		}

		private void Drag(Vector2 eventPosition)
		{
			if (!_caughtObject)
			{
				return;
			}
			
			LayerMask layer = _caughtObject.layer;
				
			switch (layer)
			{
				case 8: //Item
				{
					DragItem(eventPosition);
					return;
				}
			}
		}

		private void Drop(Vector2 eventPosition)
		{
			if (!_caughtObject)
			{
				return;
			}
			
			LayerMask layer = _caughtObject.layer;
				
			switch (layer)
			{
				case 8: //Item
				{
					DropItem();
					_caughtObject = null;
					_caughtObjectAsItem = null;
					return;
				}
			}
		}

		private void SetAsItem()
		{
			_caughtObjectAsItem = _caughtObject.GetComponent<Item>();
			_caughtObjectAsItem.IsCaught = true;
		}

		private void SetAsGardenObject()
		{
			GardenObject gardenObject = _caughtObject.GetComponent<GardenObject>();
			gardenObject.TakeTheBasket();
		}

		private void DragItem(Vector2 eventPosition)
		{
			_caughtObject.transform.position = eventPosition;
			
			GameObject hitObject = Utils.GetRaycastHitObject(_caughtObject.transform.position);

			if (!hitObject)
			{
				return;
			}
			
			LayerMask layer = hitObject.layer;
				
			switch (layer)
			{
				case 9: //Garden Place
				{
					_caughtObjectAsItem.ActiveSelector = true;
					return;
				}
				default:
				{
					if (_caughtObjectAsItem)
					{ 
						_caughtObjectAsItem.ActiveSelector = false;
					}
					return;
				}
			}
		}

		private void DropItem()
		{
			_caughtObjectAsItem.IsCaught = false;

			GameObject hitObject = Utils.GetRaycastHitObject(_caughtObject.transform.position);

			if (!hitObject)
			{
				return;
			}
			
			LayerMask layer = hitObject.layer;
				
			switch (layer)
			{
				case 9: //Garden Place
				{
					DropOnPlace(hitObject);
					break;
				}
			}
		}

		private void DropOnPlace(GameObject hitObject)
		{
			GardenPlace place = hitObject.GetComponent<GardenPlace>();
			place.UpdateCondition(_caughtObjectAsItem);
		}

	}
}