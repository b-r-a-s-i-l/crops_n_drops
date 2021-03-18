using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Inventory;
using CropsNDrops.Scripts.Scriptables.Plants;
using UnityEngine;

namespace CropsNDrops.Scripts.Garden.Plants
{
	public class GardenPlant : MonoBehaviour
	{
		[Header("Definitions")]
		[SerializeField] private SpriteRenderer _renderer = default;
		[SerializeField] private Animator _animator = default;

		[Header("Informations")]
		[SerializeField] private PlantDisplay _display = default;

		public virtual void Initialize(PlantDisplay display)
		{ }
		
		public virtual void DropOnMe(ElementItem elementItem)
		{ }

		public SpriteRenderer Renderer
		{
			get { return _renderer; }
			set { _renderer = value; }
		}

		public PlantDisplay Display
		{
			get { return _display; }
			set { _display = value; }
		}
	}
}