using System.Collections;
using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Garden.Plants;
using CropsNDrops.Scripts.Garden.Structures;
using CropsNDrops.Scripts.Input;
using CropsNDrops.Scripts.Inventory;
using CropsNDrops.Scripts.Inventory.ItemDerivations;
using CropsNDrops.Scripts.Tools;
using UnityEngine;

namespace CropsNDrops.Scripts.Player
{
	public class PlayerController : MonoBehaviour
	{
		public delegate void ScoreEvent(CropPlant plant);
		public event ScoreEvent PutInBasket; 

		[Header("Definitions")]
		[SerializeField] private InputManager _input = default;
		
		[Header("Informations")]
		[SerializeField] private GameObject _caughtObject = default;
		[SerializeField] private ItemBox _caughtItemBox = default;
		public void Initialize()
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
				case 10: //GardenPlant
				{
					CatchAsPlant();
					return;
				}
				case 11: //ItemBox
				{
					CatchAsItemBox();
					return;
				}
			}
		}

		private void CatchAsItemBox()
		{
			_caughtItemBox = _caughtObject.GetComponent<ItemBox>();
			_caughtItemBox.SetIsCaught = true;
			_caughtItemBox.Emitter.SetParameter("itemBoxAction",0 );
			_caughtItemBox.Emitter.Play();
			StartCoroutine(_caughtItemBox.ScaleItemBox(1.3f));
		}

		private void CatchAsPlant()
		{
			CropPlant cropPlant = _caughtObject.GetComponent<CropPlant>();
			
			if (cropPlant)
			{
				if (cropPlant.ActualsStage == PlantStage.RIPE)
				{
					cropPlant.Emitter.Play();
					OnPutInBasket(cropPlant);
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
				case 11: //ItemBox
				{
					DragItemBox(eventPosition);
					return;
				}
			}
		}

		private void DragItemBox(Vector2 eventPosition)
		{
			_caughtItemBox.transform.position = eventPosition;
			
			foreach (Item itemOfBox in _caughtItemBox.Items)
			{
				StartCoroutine(CheckItemCollidedSomething(itemOfBox));
			}
			
		}

		private IEnumerator CheckItemCollidedSomething(Item itemOfBox)
		{
			GameObject hitObject = Utils.GetRaycastHitObject(itemOfBox.transform.position);

			if (!hitObject)
			{
				if (itemOfBox)
				{ 
					itemOfBox.ActiveSelector = false;
				}
				
				yield break;
			}
			
			LayerMask layer = hitObject.layer;
				
			switch (layer)
			{
				case 9: //Land
				{
					DragItemOnLand(hitObject, itemOfBox);
					yield break;
				}
				case 10: //Plant
				{
					DragItemOnPlant(hitObject, itemOfBox);
					yield break;
				}
			}
		}

		private void DragItemOnLand(GameObject hitObject, Item itemOfBox)
		{
			GardenLand land = hitObject.GetComponent<GardenLand>();
			
			switch (itemOfBox)
			{
				case PlantItem _:
				{
					if (land.Condition == PlaceCondition.NORMAL)
					{
						itemOfBox.ActiveSelector = true;
					}
					return;
				}
				case ElementItem _:
				{
					itemOfBox.ActiveSelector = true;
					return;
				}
			}
		}

		private void DragItemOnPlant(GameObject hitObject, Item itemOfBox)
		{
			GardenPlant plant = hitObject.GetComponent<GardenPlant>();

			switch (plant)
			{
				case CropPlant _:
				{
					itemOfBox.ActiveSelector = true;
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
				case 11: //ItemBox
				{
					DropItemBox();
					_caughtObject = null;
					_caughtItemBox = null;
					
					return;
				}
			}
		}

		private void DropItemBox()
		{
			_caughtItemBox.SetIsCaught = false;

			if (!_caughtItemBox.AllItemsCanDrop)
			{
				_caughtItemBox.DesactiveAllSelector();
				StartCoroutine(_caughtItemBox.ScaleItemBox(1));
				return;
			}
			
			foreach (Item itemOfBox in _caughtItemBox.Items)
			{
				GameObject hitObject = Utils.GetRaycastHitObject(itemOfBox.transform.position);

				if (!hitObject)
				{
					return;
				}

				LayerMask layer = hitObject.layer;

				switch (layer)
				{
					case 9: //Land
					{
						DropOnLand(hitObject, itemOfBox);
						break;
					}
					case 10: //Plant
					{
						DropOnPlant(hitObject, itemOfBox);
						break;
					}
				}
				
				Destroy(_caughtObject);
			}
		}

		private void DropOnLand(GameObject hitObject, Item itemOfBox)
		{
			_caughtItemBox.Emitter.SetParameter("itemBoxAction",1 );
			_caughtItemBox.Emitter.Play();
			
			GardenLand land = hitObject.GetComponent<GardenLand>();

			switch (itemOfBox)
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
		
		private void DropOnPlant(GameObject hitObject, Item itemOfBox)
		{
			_caughtItemBox.Emitter.SetParameter("itemBoxAction",1 );
			_caughtItemBox.Emitter.Play();
			
			GardenPlant plant = hitObject.GetComponent<GardenPlant>();
			
			switch (plant)
			{
				case CropPlant _:
				{
					plant.DropOnMe(itemOfBox);
					return;
				}
			}
		}

		protected virtual void OnPutInBasket(CropPlant plant)
		{
			PutInBasket?.Invoke(plant);
		}
	}
}