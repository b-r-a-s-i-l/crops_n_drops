using CropsNDrops.Scripts.Enum;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden
{
	public class GardenFence : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private SpriteRenderer _spriteRenderer = default;
		[SerializeField] private Sprite[] _sprites = default;
		public void PutMe(Vector2 position, FenceDirection direction)
		{
			name = $"Fence - x: {position.x} , y: {position.y}";
			_spriteRenderer.sprite = _sprites[(int) direction];
			transform.localPosition = position;
		}
	}
}