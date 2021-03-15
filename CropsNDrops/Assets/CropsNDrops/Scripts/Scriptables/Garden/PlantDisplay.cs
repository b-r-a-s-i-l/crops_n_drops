using CropsNDrops.Scripts.Enum;
using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Garden
{
	[CreateAssetMenu(fileName = "New Plant", menuName = "Plant Object")]
	public class PlantDisplay : ScriptableObject
	{
		public PlantType type  = default;
		public PlantStage stage  = default;
		public Sprite[] sprites = new Sprite[6];
	}
}