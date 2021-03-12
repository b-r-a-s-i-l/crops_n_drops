using System;
using System.Collections;
using System.Collections.Generic;
using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Inventory;
using CropsNDrops.Scripts.Scriptables.Garden;
using CropsNDrops.Scripts.Scriptables.Inventory;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden
{
	public class GardenPlace : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private GardenPlant gardenPlantPrefab = default;
		[SerializeField] private Animator _fx = default;
		[SerializeField] private SpriteRenderer _renderer = default;
		[SerializeField] private Sprite[] _sprites = default;

		[Header("Informations")]
		[SerializeField] private Vector2 _positionId = default;
		[SerializeField] private PlaceCondition _condition = default;
		[SerializeField] private GardenPlant _planted = default;
		[SerializeField] private List<GardenPlace> _neighbours = new List<GardenPlace>();
		public void Inicialize(Vector3 position)
		{
			name = $"Place - x: {position.x} , y: {position.y}";
			transform.localPosition = position;
			_positionId = new Vector2(position.x, position.y);
		}
		public void UpdateCondition(Item item)
		{
			switch (_condition)
			{
				case PlaceCondition.NORMAL:
				{
					ApllyItemInNormalCondition(item);
					return;
				}
				case PlaceCondition.VERYWET:
				{
					ApllyItemInWetCondition(item);
					return;
				}
				case PlaceCondition.VERYDRY:
				{
					ApllyItemInDryCondition(item);
					return;
				}
			}
		}
		
		private void ApllyItemInNormalCondition(Item item)
		{
			switch (item.Type)
			{
				case ItemType.PLANT:
				{
					//PlantItemDisplay plant = item.Display as PlantItemDisplay;
					Destroy(item.gameObject);
					ExecuteAnimation("Smoke");
					//PlantOnMe(plant.plantDisplay);
					Condition = PlaceCondition.NORMAL;
					
					return;
				}
				// case ItemType.WATER:
				// {
				// 	Destroy(item.gameObject);
				// 	ExecuteAnimation("Water");
				// 	Condition = PlaceCondition.VERYWET;
				// 	
				// 	return;
				// }
				// case ItemType.SUNSHINE:
				// {
				// 	Destroy(item.gameObject);
				// 	ExecuteAnimation("Sunshine");
				// 	Condition = PlaceCondition.VERYDRY;
				// 	
				// 	return;
				// }
			}
		}
		
		private void ApllyItemInWetCondition(Item item)
		{
			switch (item.Type)
			{
				case ItemType.PLANT:
				{
					//não rola
					return;
				}
				// case ItemType.WATER:
				// {
				// 	//vai dar merda
				// 	return;
				// }
				// case ItemType.SUNSHINE:
				// {
				// 	Destroy(item.gameObject);
				// 	ExecuteAnimation("Sunshine");
				// 	Condition = PlaceCondition.NORMAL;
				// 	
				// 	return;
				// }
			}
		}
		
		private void ApllyItemInDryCondition(Item item)
		{
			switch (item.Type)
			{
				case ItemType.PLANT:
				{
					//não rola
					return;
				}
				// case ItemType.WATER:
				// {
				// 	Destroy(item.gameObject);
				// 	ExecuteAnimation("Water");
				// 	Condition = PlaceCondition.NORMAL;
				// 	
				// 	return;
				// }
				// case ItemType.SUNSHINE:
				// {
				// 	//vaidar merda
				// 	return;
				// }
			}
		}

		private void PlantOnMe(PlantDisplay display)
		{
			GardenPlant gardenPlant = Instantiate(GardenPlantPrefab, transform);
			gardenPlant.Initialize(display);
			Planted = gardenPlant;
		}

		private void ExecuteAnimation(string id)
		{
			_fx.SetTrigger(id);
		}

		public Vector2 PositionId
		{
			get { return _positionId; }
		}

		public GardenPlant GardenPlantPrefab
		{
			get { return gardenPlantPrefab; }
		}

		public GardenPlant Planted
		{
			get { return _planted; }
			set { _planted = value; }
		}

		public PlaceCondition Condition
		{
			get { return _condition; }
			set
			{
				_condition = value;
				_renderer.sprite = _sprites[(int)value];
			}
		}

		public List<GardenPlace> Neighbours
		{
			get { return _neighbours; }
			set { _neighbours = value; }
		}
	}
}