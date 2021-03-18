using System;
using System.Collections.Generic;
using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Garden.Plants;
using CropsNDrops.Scripts.Inventory;
using CropsNDrops.Scripts.Scriptables.Garden;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden.Structures
{
	public class GardenLand : GardenStructures
	{
		[Header("Land Specifications")]
		[SerializeField] private LandDisplay _landDisplay = default;
		[SerializeField] private PlaceCondition _condition = default;
		[SerializeField] private BoxCollider _boxCollider = default;
		[SerializeField] private Animator _animator = default;
		[SerializeField] private GardenPlant[] plantPrefab = default;
		[SerializeField] private List<GardenLand> _neighbours = new List<GardenLand>();
		
		[Header("Plant")]
		[SerializeField] private GardenPlant _planted = default;

		private void Update()
		{
			_boxCollider.enabled = !_planted;
		}

		public override void Initialize(int x, int y)
		{
			Type = StrutureType.LAND;
			Position = new Vector2(x, y);
			name = $"Place - x: {Position.x} , y: {Position.y}";
			transform.localPosition = Position;
			SetPlaceCondition(PlaceCondition.NORMAL);
		}
		
		public void PlantOnMe(PlantItem plant)
		{
			PlantType plantType = plant.PlantDisplay.PlantType;

			if (GetPrefabOfPlant(plantType) is CropPlant crop)
			{
				plant.ExecuteAnimationAndDestroy();
				
				CropPlant instance = Instantiate(crop, transform);
				instance.Initialize(plant.PlantDisplay);
				_planted = instance;
				
				ExecuteAnimation("Smoke");
			}
		}

		public void ChangeLandCondition(ElementItem element)
		{
			switch (element.ElementType)
			{
				case ElementType.WATER:
				{
					switch (_condition)
					{
						case PlaceCondition.NORMAL:
						{
							element.ExecuteAnimationAndDestroy();
							SetPlaceCondition(PlaceCondition.VERYWET);
							ExecuteAnimation("Water");
							return;	
						}
						case PlaceCondition.VERYWET:
						{
							if (GetPrefabOfPlant(PlantType.WEEDPLANT) is WeedPlant weed)
							{
								element.ExecuteAnimationAndDestroy();
								
								WeedPlant instance = Instantiate(weed, transform);
								instance.Initialize(weed.Display);
								_planted = instance;
								
								ExecuteAnimation("Smoke");
							}
							return;	
						}
						case PlaceCondition.VERYDRY:
						{
							element.ExecuteAnimationAndDestroy();
							SetPlaceCondition(PlaceCondition.NORMAL);
							ExecuteAnimation("Water");
							return;	
						}
					}
					
					return;	
				}
				case ElementType.SUNSHINE:
				{
					switch (_condition)
					{
						case PlaceCondition.NORMAL:
						{
							element.ExecuteAnimationAndDestroy();
							SetPlaceCondition(PlaceCondition.VERYDRY);
							ExecuteAnimation("Sunshine");
							return;	
						}
						case PlaceCondition.VERYWET:
						{
							element.ExecuteAnimationAndDestroy();
							SetPlaceCondition(PlaceCondition.NORMAL);
							ExecuteAnimation("Sunshine");
							return;	
						}
						case PlaceCondition.VERYDRY:
						{
							if (GetPrefabOfPlant(PlantType.WEEDPLANT) is WeedPlant weed)
							{
								element.ExecuteAnimationAndDestroy();
								
								WeedPlant instance = Instantiate(weed, transform);
								instance.Initialize(weed.Display);
								_planted = instance;
								
								ExecuteAnimation("Smoke");
							}
							return;
						}
					}
					
					return;	
				}
			}
		}

		private void SetPlaceCondition(PlaceCondition condition)
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
					Renderer.sprite = _landDisplay.wet;
					break;
				}
				case PlaceCondition.VERYDRY:
				{
					Renderer.sprite = _landDisplay.dry;
					break;
				}
			}
			
			_condition = condition;
		}

		private GardenPlant GetPrefabOfPlant(PlantType type)
		{
			foreach (GardenPlant plant in plantPrefab)
			{
				if (plant is CropPlant && type == PlantType.CROPPLANT)
				{
					return plant;
				}
				if (plant is WeedPlant && type == PlantType.WEEDPLANT)
				{
					return plant;
				}
			}

			return null;
		}

		public PlaceCondition Condition
		{
			get { return _condition; }
			set { _condition = value; }
		}
		
		public List<GardenLand> Neighbours
		{
			get { return _neighbours; }
			set { _neighbours = value; }
		}

		private void ExecuteAnimation(string id)
		{
			_animator.SetTrigger(id);
		}
	}
}