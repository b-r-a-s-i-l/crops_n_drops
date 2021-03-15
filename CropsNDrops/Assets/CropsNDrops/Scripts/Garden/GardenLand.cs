using System;
using System.Collections.Generic;
using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Inventory;
using CropsNDrops.Scripts.Scriptables.Garden;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden
{
	public class GardenLand : GardenStructures
	{
		[Header("Land Specifications")]
		[SerializeField] private LandDisplay _landDisplay = default;
		[SerializeField] private PlaceCondition _condition = default;
		[SerializeField] private Animator _fx = default;
		[SerializeField] private List<GardenLand> _neighbours = new List<GardenLand>();
		
		[Header("Land Object")]
		[SerializeField] private GardenPlant _landObjectPrefab = default;
		[SerializeField] private GardenPlant _planted = default;
		public override void Initialize(int x, int y)
		{
			Type = StrutureType.LAND;
			Position = new Vector2(x, y);
			name = $"Place - x: {Position.x} , y: {Position.y}";
			transform.localPosition = Position;
			ChangeLandCondition(PlaceCondition.NORMAL);
		}

		private void ChangeLandCondition(PlaceCondition condition)
		{
			switch (condition)
			{
				case PlaceCondition.NORMAL:
				{
					Renderer.sprite = _landDisplay.normal;
					break;
				}
				case PlaceCondition.VERYWET:
				{
					Renderer.sprite = _landDisplay.normal;
					break;
				}
				case PlaceCondition.VERYDRY:
				{
					Renderer.sprite = _landDisplay.normal;
					break;
				}
			}
			
			_condition = condition;
		}
		
		public List<GardenLand> Neighbours
		{
			get { return _neighbours; }
			set { _neighbours = value; }
		}
		
		
		// public void UpdateCondition(Item item)
		// {
		// 	switch (_condition)
		// 	{
		// 		case PlaceCondition.NORMAL:
		// 		{
		// 			ApllyItemInNormalCondition(item);
		// 			return;
		// 		}
		// 		case PlaceCondition.VERYWET:
		// 		{
		// 			ApllyItemInWetCondition(item);
		// 			return;
		// 		}
		// 		case PlaceCondition.VERYDRY:
		// 		{
		// 			ApllyItemInDryCondition(item);
		// 			return;
		// 		}
		// 	}
		// }
		//
		// private void ApllyItemInNormalCondition(Item item)
		// {
		// 	switch (item.Type)
		// 	{
		// 		case ItemType.PLANT:
		// 		{
		// 			//PlantItemDisplay plant = item.Display as PlantItemDisplay;
		// 			Destroy(item.gameObject);
		// 			ExecuteAnimation("Smoke");
		// 			//PlantOnMe(plant.plantDisplay);
		// 			Condition = PlaceCondition.NORMAL;
		// 			
		// 			return;
		// 		}
		// 		case ItemType.WATER:
		// 		{
		// 			Destroy(item.gameObject);
		// 			ExecuteAnimation("Water");
		// 			Condition = PlaceCondition.VERYWET;
		// 			
		// 			return;
		// 		}
		// 		case ItemType.SUNSHINE:
		// 		{
		// 			Destroy(item.gameObject);
		// 			ExecuteAnimation("Sunshine");
		// 			Condition = PlaceCondition.VERYDRY;
		// 			
		// 			return;
		// 		}
		// 	}
		// }
		//
		// private void ApllyItemInWetCondition(Item item)
		// {
		// 	switch (item.Type)
		// 	{
		// 		case ItemType.PLANT:
		// 		{
		// 			//não rola
		// 			return;
		// 		}
		// 		case ItemType.WATER:
		// 		{
		// 			//vai dar merda
		// 			return;
		// 		}
		// 		case ItemType.SUNSHINE:
		// 		{
		// 			Destroy(item.gameObject);
		// 			ExecuteAnimation("Sunshine");
		// 			Condition = PlaceCondition.NORMAL;
		// 			
		// 			return;
		// 		}
		// 	}
		// }
		//
		// private void ApllyItemInDryCondition(Item item)
		// {
		// 	switch (item.Type)
		// 	{
		// 		case ItemType.PLANT:
		// 		{
		// 			//não rola
		// 			return;
		// 		}
		// 		case ItemType.WATER:
		// 		{
		// 			Destroy(item.gameObject);
		// 			ExecuteAnimation("Water");
		// 			Condition = PlaceCondition.NORMAL;
		// 			
		// 			return;
		// 		}
		// 		case ItemType.SUNSHINE:
		// 		{
		// 			//vaidar merda
		// 			return;
		// 		}
		// 	}
		// }
		//
		// private void PlantOnMe(PlantDisplay display)
		// {
		// 	GardenPlant gardenPlant = Instantiate(GardenPlantPrefab, transform);
		// 	gardenPlant.Initialize(display);
		// 	Planted = gardenPlant;
		// }

		// private void ExecuteAnimation(string id)
		// {
		// 	_fx.SetTrigger(id);
		// }
		// public GardenPlant GardenPlantPrefab
		// {
		// 	get { return gardenPlantPrefab; }
		// }
		//
		// public GardenPlant Planted
		// {
		// 	get { return _planted; }
		// 	set { _planted = value; }
		// }
		//
		// public PlaceCondition Condition
		// {
		// 	get { return _condition; }
		// 	set
		// 	{
		// 		_condition = value;
		// 		Renderer.sprite = _sprites[(int)value];
		// 	}
		// }
	}
}