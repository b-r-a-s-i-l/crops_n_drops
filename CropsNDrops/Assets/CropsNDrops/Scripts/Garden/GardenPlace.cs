using System;
using System.Collections;
using System.Collections.Generic;
using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Scriptables.Garden;
using CropsNDrops.Scripts.Scriptables.Inventory;
using CropsNDrops.Scripts.UI;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden
{
	public class GardenPlace : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private GardenObject _gardenObjectPrefab = default;
		[SerializeField] private GameObject _selector = default;
		[SerializeField] private Animator _fx = default;
		[SerializeField] private SpriteRenderer _renderer = default;
		[SerializeField] private Sprite[] _sprites = default;

		[Header("Informations")]
		[SerializeField] private Vector2 _positionId = default;
		[SerializeField] private PlaceCondition _condition = default;
		[SerializeField] private GardenObject _planted = default;
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
					ExecuteAnimation("Smoke");
					SeedItem seed = item.Display as SeedItem;
					Destroy(item.gameObject);
					PlantOnMe(seed.plantDisplay);
					Condition = PlaceCondition.NORMAL;
					//Destroy(item.gameObject);
					return;
				}
				case ItemType.WATER:
				{
					ExecuteAnimation("Water");
					Condition = PlaceCondition.VERYWET;
					Destroy(item.gameObject);
					return;
				}
				case ItemType.SUNSHINE:
				{
					ExecuteAnimation("Sunshine");
					Condition = PlaceCondition.VERYDRY;
					Destroy(item.gameObject);
					return;
				}
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
				case ItemType.WATER:
				{
					//vai dar merda
					return;
				}
				case ItemType.SUNSHINE:
				{
					ExecuteAnimation("Sunshine");
					Condition = PlaceCondition.NORMAL;
					Destroy(item.gameObject);
					return;
				}
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
				case ItemType.WATER:
				{
					ExecuteAnimation("Water");
					Condition = PlaceCondition.NORMAL;
					Destroy(item.gameObject);
					return;
				}
				case ItemType.SUNSHINE:
				{
					//vaidar merda
					return;
				}
			}
		}

		private void PlantOnMe(PlantDisplay display)
		{
			GardenObject gardenObject = Instantiate(GardenObjectPrefab, transform);
			gardenObject.Initialize(display);
			Planted = gardenObject;
		}

		private void ExecuteAnimation(string id)
		{
			_fx.SetTrigger(id);
		}

		public Vector2 PositionId
		{
			get { return _positionId; }
		}

		public GardenObject GardenObjectPrefab
		{
			get { return _gardenObjectPrefab; }
		}

		public GardenObject Planted
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