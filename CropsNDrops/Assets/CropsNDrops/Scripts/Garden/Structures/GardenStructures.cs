using CropsNDrops.Scripts.Enum;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden.Structures
{
	public class GardenStructures : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private SpriteRenderer _renderer = default;

		[Header("Informations")]
		[SerializeField] private Vector2 _position = default;
		[SerializeField] private StrutureType _type = default;

		public virtual void Initialize(int x, int y) {}
		
		public Vector2 Position
		{
			get { return _position; }
			set { _position = value; }
		}

		public StrutureType Type
		{
			get { return _type; }
			set { _type = value; }
		}

		public SpriteRenderer Renderer
		{
			get { return _renderer; }
			set { _renderer = value; }
		}
	}
}