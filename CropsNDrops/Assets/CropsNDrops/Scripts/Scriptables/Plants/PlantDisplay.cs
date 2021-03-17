using CropsNDrops.Scripts.Enum;
using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Plants
{
	public class PlantDisplay : ScriptableObject
	{
		private PlantType _plantType  = default;
		public PlantType PlantType
		{
			get { return _plantType; }
			set { _plantType = value; }
		}
	}
}