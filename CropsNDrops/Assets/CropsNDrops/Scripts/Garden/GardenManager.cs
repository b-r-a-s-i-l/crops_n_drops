using System.Collections.Generic;
using CropsNDrops.Scripts.Enum;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden
{
	public class GardenManager : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private GardenPlace _gardenPlacePrefab = default;
		[SerializeField] private GardenFence _gardenFencePrefab = default;
		
		[Header("Informations")]
		[SerializeField] private int _gridSizeX = default;
		[SerializeField] private int _gridSizeY = default;
		[SerializeField] private float _xOffset = default;
		[SerializeField] private float _yOffset = default;
		[SerializeField] private List<GardenPlace> _allPlaces = new List<GardenPlace>();
		
		public void Initialize(int width, int height)
		{
			_gridSizeX = width;
			_gridSizeY = height;
			AdjustGardenOffset();
			CreateGarden(_gridSizeX, _gridSizeY);
			SetNeighboursOfPlaces();
		}

		private void AdjustGardenOffset()
		{
			for (int i = 0; i <= _gridSizeX; i++)
			{
				if (i % 2 == 0 && i > 2)
				{
					_xOffset -= 1;
				}
			}
			for (int j = 0; j <= _gridSizeY; j++)
			{
				if (j % 2 == 0 && j > 2)
				{
					_yOffset -= 1;
				}
			}

			transform.position = new Vector3(_xOffset, _yOffset);
		}
		
		private void CreateGarden(int maxSizeX, int maxSizeY)
		{
			for (int x = 0; x < maxSizeX; x++)
			{
				for (int y = 0; y < maxSizeY; y++)
				{
					Vector3 position = new Vector3(x, y);
					GardenPlace place = Instantiate(_gardenPlacePrefab, transform);
					place.Inicialize(position);
					_allPlaces.Add(place);
					
					CheckNeedFenceThisPosition(x, y);
				}
			}
		}

		private void CheckNeedFenceThisPosition(int x, int y)
		{
			if (x == 0)
			{
				if (y == 0)
				{
					PutFence(x - 1, y - 1, FenceDirection.BUTTON_LEFT);
				}
				if (y <= _gridSizeY - 1)
				{
					PutFence(x - 1, y, FenceDirection.LEFT);
				}
				if (y == _gridSizeY - 1)
				{
					PutFence(x - 1, y + 1, FenceDirection.TOP_LEFT);
				}
			}
			if (x >= 0 && x <= _gridSizeX - 1)
			{
				if (y == 0)
				{
					PutFence(x, y - 1, FenceDirection.BUTTON_MIDDLE);
				}
				if (y == _gridSizeY - 1)
				{
					PutFence(x, y + 1, FenceDirection.TOP_MIDDLE);
				}	
			}
			if (x == _gridSizeX - 1)
			{
				if (y == 0)
				{
					PutFence(x + 1, y - 1, FenceDirection.BUTTON_RIGHT);
				}
				if (y <= _gridSizeY - 1)
				{
					PutFence(x + 1, y, FenceDirection.RIGHT);
				}
				if (y == _gridSizeY - 1)
				{
					PutFence(x + 1, y + 1, FenceDirection.TOP_RIGHT);
				}
			}
		}

		private void PutFence(int x, int y, FenceDirection direction )
		{
			Vector3 position = new Vector3(x, y);
			GardenFence fence = Instantiate(_gardenFencePrefab, transform);
			fence.PutMe(position, direction);
		}
		
		 private void SetNeighboursOfPlaces()
		 {
		 	foreach (GardenPlace place in _allPlaces)
		 	{
		 		List<GardenPlace> neighbours = new List<GardenPlace>();
		 		Vector2 placeId = place.PositionId;
		 		int xOfPlace = (int) placeId.x;
		 		int yOfPlace = (int) placeId.y;
		 	
		 		for (int i = -1; i <= 1; i++)
		 		{
		 			for (int j = -1; j <= 1; j++)
		 			{
		 				int xOfNeighbour = default;
		 				int yOfNeighbour = default;
		 				
		 				if (xOfPlace == 0)
		 				{ 
		 					xOfNeighbour = xOfPlace + i;
		 				}
		 				else if (xOfPlace > 0 && xOfPlace < _gridSizeX - 1)
		 				{
		 					xOfNeighbour = (xOfPlace + i + _gridSizeX) % _gridSizeX;
		 				}
		 				else if (xOfPlace == _gridSizeX - 1)
		 				{
		 					xOfNeighbour = xOfPlace + i;
		 				}
		 				
		 				if (yOfPlace == 0)
		 				{
		 					yOfNeighbour = yOfPlace + j;
		 				}
		 				else if (yOfPlace > 0 && yOfPlace < _gridSizeY - 1)
		 				{
		 					yOfNeighbour = (yOfPlace + j + _gridSizeY) % _gridSizeY;
		 				}
		 				else if (yOfPlace == _gridSizeY - 1)
		 				{
		 					yOfNeighbour = yOfPlace + j;
		 				}
		 				
		 				Vector2 neighbourId = new Vector2(xOfNeighbour, yOfNeighbour);
		 			
		 				foreach (GardenPlace neighbour in _allPlaces)
		 				{
		 					if (neighbour.PositionId == neighbourId && neighbour.PositionId != place.PositionId)
		 					{
		 						neighbours.Add(neighbour);
		 					}
		 				}
		 			}
		 		}
		 		
		 		place.Neighbours = neighbours;
		 	}
		}
	}
}
	