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
			//GardenPlant gardenPlant = _caughtObject.GetComponent<GardenPlant>();
			//gardenPlant.TakeTheBasket();
		}

		private void DragItem(Vector2 eventPosition)
		{
			_caughtObject.transform.position = eventPosition;
			
			GameObject hitObject = Utils.GetRaycastHitObject(_caughtObject.transform.position);

			if (!hitObject)
			{
				if (_caughtObjectAsItem)
				{ 
					_caughtObjectAsItem.ActiveSelector = false;
				}
				
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
				case 10: //Garden Object
				{
					_caughtObjectAsItem.ActiveSelector = true;
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
					DropOnLand(hitObject);
					return;
				}
				case 10: //Garden Object
				{
					DropOnPlant(hitObject);
					return;
				}
			}
		}

		private void DropOnLand(GameObject hitObject)
		{
			GardenLand land = hitObject.GetComponent<GardenLand>();

			if (_caughtObjectAsItem is PlantItem plantItem)
			{
				land.PlantOnMe(plantItem);
			}
			if (_caughtObjectAsItem is ElementItem elementItem)
			{
				land.ChangeLandCondition(elementItem);
			}
			
		}
		
		private void DropOnPlant(GameObject hitObject)
		{
			GardenPlant plant = hitObject.GetComponent<GardenPlant>();

			if (_caughtObjectAsItem is PlantItem plantItem)
			{
				//destruir a planta plantada
			}
			if (_caughtObjectAsItem is ElementItem elementItem)
			{
				plant.DropOnMe(elementItem);
			}
		}

	}
}