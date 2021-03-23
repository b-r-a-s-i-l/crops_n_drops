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
		[SerializeField] private PlantSettings settings = default;

		public virtual void Initialize(PlantSettings settings)
		{ }
		
		public virtual void DropOnMe(Item item)
		{ }
		
		public PlantSettings Settings
		{
			get { return settings; }
			protected set { settings = value; }
		}

		protected void ExecuteAnimation(string id)
		{
			_animator.SetTrigger(id);
		}

		protected SpriteRenderer Renderer
		{
			get { return _renderer; }
		}
	}
}