using System;
using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Garden.Plants;
using CropsNDrops.Scripts.Garden.Structures;
using CropsNDrops.Scripts.Input;
using CropsNDrops.Scripts.Inventory;
using CropsNDrops.Scripts.Tools;
using UnityEngine;

namespace CropsNDrops.Scripts.Player
{
	public class Player : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private InputManager _input = default;
		
		[Header("Informations")]
		[SerializeField] private GameObject _caughtObject = default;
		[SerializeField] private Item _caughtItem = default;
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
			GameObject hit = Utils.GetRaycastHitObject(eventPosition, true);

			if (!hit)
			{
				hit = Utils.GetRaycastHitObject(eventPosition);
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
					CatchAsItem();
					return;
				}
				case 10: //GardenObject
				{
					CatchAsPlant();
					return;
				}
			}
		}

		private void CatchAsItem()
		{
			_caughtItem = _caughtObject.GetComponent<Item>();
			_caughtItem.IsCaught = true;
		}

		private void CatchAsPlant()
		{
			//
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

		private void DragItem(Vector2 eventPosition)
		{
			_caughtItem.transform.position = eventPosition;
			
			GameObject hitObject = Utils.GetRaycastHitObject(_caughtItem.transform.position);

			if (!hitObject)
			{
				if (_caughtItem)
				{ 
					_caughtItem.ActiveSelector = false;
				}
				
				return;
			}
			
			LayerMask layer = hitObject.layer;
				
			switch (layer)
			{
				case 9: //Land
				{
					DragItemOnLand(hitObject);
					return;
				}
				case 10: //Plant
				{
					DragItemOnPlant(hitObject);
					return;
				}
			}
		}

		private void DragItemOnLand(GameObject hitObject)
		{
			GardenLand land = hitObject.GetComponent<GardenLand>();

			switch (_caughtItem)
			{
				case PlantItem _:
				{
					if (land.Condition == PlaceCondition.NORMAL)
					{
						_caughtItem.ActiveSelector = true;
					}
					return;
				}
				case ElementItem _:
				{
					_caughtItem.ActiveSelector = true;
					return;
				}
			}
		}

		private void DragItemOnPlant(GameObject hitObject)
		{
			GardenPlant plant = hitObject.GetComponent<GardenPlant>();

			switch (plant)
			{
				case CropPlant _:
				{
					_caughtItem.ActiveSelector = true;
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
					_caughtItem = null;
					return;
				}
			}
		}

		private void DropItem()
		{
			_caughtItem.IsCaught = false;
			
			GameObject hitObject = Utils.GetRaycastHitObject(_caughtItem.transform.position);

			if (!hitObject)
			{
				return;
			}
			
			LayerMask layer = hitObject.layer;
				
			switch (layer)
			{
				case 9: //Land
				{
					DropOnLand(hitObject);
					break;
				}
				case 10: //Plant
				{
					DropOnPlant(hitObject);
					break;
				}
			}
		}

		private void DropOnLand(GameObject hitObject)
		{
			GardenLand land = hitObject.GetComponent<GardenLand>();

			switch (_caughtItem)
			{
				case PlantItem plantItem:
				{
					if (land.Condition == PlaceCondition.NORMAL)
					{
						land.PlantOnMe(plantItem);
					}
					return;
				}
				case ElementItem elementItem:
				{
					land.ChangeLandCondition(elementItem);
					return;
				}
			}
		}
		
		private void DropOnPlant(GameObject hitObject)
		{
			GardenPlant plant = hitObject.GetComponent<GardenPlant>();
			
			switch (plant)
			{
				case CropPlant _:
				{
					plant.DropOnMe(_caughtItem);
					return;
				}
			}
		}
	}
}