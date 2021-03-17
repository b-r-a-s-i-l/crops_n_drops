using System.Collections.Generic;
using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Garden.Structures;
using CropsNDrops.Scripts.Scriptables.Garden;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden
{
	public class GardenManager : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private GardenStructures[] _gardenPrefabs = default;
		[SerializeField] private FenceDisplay _fencesDisplay = default;


		[Header("Informations")]
		[SerializeField] private int _gridSizeX = default;
		[SerializeField] private int _gridSizeY = default;
		[SerializeField] private float _xOffset = default;
		[SerializeField] private float _yOffset = default;
		[SerializeField] private List<GardenLand> _allLands = new List<GardenLand>();
		
		public void Initialize(int width, int height)
		{
			_gridSizeX = width;
			_gridSizeY = height;
			AdjustGardenOffset();
			CreateGarden(_gridSizeX, _gridSizeY);
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
			for (int x = -1; x <= maxSizeX; x++)
			{
				for (int y = -1; y <= maxSizeY; y++)
				{
					if (x == -1)
					{
						if (y == -1)
						{
							// cerca inferior esquerda
							if (GetPrefabOfStruture(StrutureType.FENCE) is GardenFence fence)
							{
								GardenFence instance = Instantiate(fence, transform);
								instance.Initialize(x,y);
								instance.SetFence(_fencesDisplay.bottomLeft, FenceDirection.BOTTOM_LEFT);
							}
						}
						else if (y == maxSizeY)
						{
							// cerca superior esquerda
							if (GetPrefabOfStruture(StrutureType.FENCE) is GardenFence fence)
							{
								GardenFence instance = Instantiate(fence, transform);
								instance.Initialize(x,y);
								instance.SetFence(_fencesDisplay.topLeft, FenceDirection.TOP_LEFT);
							}
						}
						else
						{
							// cerca esquerda
							if (GetPrefabOfStruture(StrutureType.FENCE) is GardenFence fence)
							{
								GardenFence instance = Instantiate(fence, transform);
								instance.Initialize(x,y);
								instance.SetFence(_fencesDisplay.left, FenceDirection.LEFT);
							}
						}
					}
					if (x >= 0 && x < maxSizeX)
					{
						if (y == -1)
						{
							// cerca baixa
							if (GetPrefabOfStruture(StrutureType.FENCE) is GardenFence fence)
							{
								GardenFence instance = Instantiate(fence, transform);
								instance.Initialize(x,y);
								instance.SetFence(_fencesDisplay.bottomMiddle, FenceDirection.BOTTOM_MIDDLE);
							}
						}
						else if (y == maxSizeY)
						{
							// creca alta
							if (GetPrefabOfStruture(StrutureType.FENCE) is GardenFence fence)
							{
								GardenFence instance = Instantiate(fence, transform);
								instance.Initialize(x,y);
								instance.SetFence(_fencesDisplay.topMiddle, FenceDirection.TOP_MIDDLE);
							}
						}
						else
						{
							//terreno
							if (GetPrefabOfStruture(StrutureType.LAND) is GardenLand land)
							{
								GardenLand instance = Instantiate(land, transform);
								instance.Initialize(x,y);
								_allLands.Add(instance);
							}
						}
					}
					if (x == maxSizeX)
					{
						if (y == -1)
						{
							// cerca inferior direita
							if (GetPrefabOfStruture(StrutureType.FENCE) is GardenFence fence)
							{
								GardenFence instance = Instantiate(fence, transform);
								instance.Initialize(x,y);
								instance.SetFence(_fencesDisplay.bottomRight, FenceDirection.BOTTOM_RIGHT);
							}
						}
						else if (y == maxSizeY)
						{
							// cerca superior direita
							if (GetPrefabOfStruture(StrutureType.FENCE) is GardenFence fence)
							{
								GardenFence instance = Instantiate(fence, transform);
								instance.Initialize(x,y);
								instance.SetFence(_fencesDisplay.topRight, FenceDirection.TOP_RIGHT);
							}
						}
						else
						{
							// cerca direito
							if (GetPrefabOfStruture(StrutureType.FENCE) is GardenFence fence)
							{
								GardenFence instance = Instantiate(fence, transform);
								instance.Initialize(x,y);
								instance.SetFence(_fencesDisplay.right, FenceDirection.RIGHT);
							}
						}
					}
				}
			}
			
			SetNeighborhoods();
		}

		private GardenStructures GetPrefabOfStruture(StrutureType type)
		{
			foreach (GardenStructures t in _gardenPrefabs)
			{
				if (t is GardenLand && type == StrutureType.LAND)
				{
					return t;
				}
				if (t is GardenFence && type == StrutureType.FENCE)
				{
					return t;
				}
			}

			return null;
		}

		 private void SetNeighborhoods()
		 {
		 	foreach (GardenLand land in _allLands)
		 	{
		 		List<GardenLand> neighbours = new List<GardenLand>();
		 		Vector2 placeId = land.Position;
		 		int x = (int) placeId.x;
		 		int y = (int) placeId.y;
		 	
		 		for (int i = -1; i <= 1; i++)
		 		{
		 			for (int j = -1; j <= 1; j++)
		 			{
		 				int xOfNeighbour = default;
		 				int yOfNeighbour = default;
		 				
		 				if (x == 0)
		 				{ 
		 					xOfNeighbour = x + i;
		 				}
		 				else if (x > 0 && x < _gridSizeX - 1)
		 				{
		 					xOfNeighbour = (x + i + _gridSizeX) % _gridSizeX;
		 				}
		 				else if (x == _gridSizeX - 1)
		 				{
		 					xOfNeighbour = x + i;
		 				}
		 				
		 				if (y == 0)
		 				{
		 					yOfNeighbour = y + j;
		 				}
		 				else if (y > 0 && y < _gridSizeY - 1)
		 				{
		 					yOfNeighbour = (y + j + _gridSizeY) % _gridSizeY;
		 				}
		 				else if (y == _gridSizeY - 1)
		 				{
		 					yOfNeighbour = y + j;
		 				}
		 				
		 				Vector2 neighbourId = new Vector2(xOfNeighbour, yOfNeighbour);
		 			
		 				foreach (GardenLand neighbour in _allLands)
		 				{
		 					if (neighbour.Position == neighbourId)
		                              {
			                              if(neighbour.Position != land.Position)
			                              {
				                              neighbours.Add(neighbour);
			                              }
		                              }
		                        }
		 			}
		 		}
		 		
		 		land.Neighbours = neighbours;
		 	}
		}
	}
}
	