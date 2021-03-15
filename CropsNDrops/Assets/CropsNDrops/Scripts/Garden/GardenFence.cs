using CropsNDrops.Scripts.Enum;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden
{
	public class GardenFence : GardenStructures
	{
		[Header("Fence Specifications")]
		[SerializeField] private FenceDirection _direction;

		public override void Initialize(int x, int y)
		{
			Type = StrutureType.FENCE;
			Position = new Vector2(x, y);
			name = $"Fence - x: {Position.x} , y: {Position.y}";
			transform.localPosition = Position;
		}

		public void SetFence(Sprite sprite, FenceDirection direction)
		{
			Renderer.sprite = sprite;
			_direction = direction;
		}
	}
}