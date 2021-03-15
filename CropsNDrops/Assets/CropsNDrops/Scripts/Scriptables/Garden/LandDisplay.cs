using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Garden
{
	[CreateAssetMenu(fileName = "New Lands", menuName = "Lands Conditions", order = 0)]
	public class LandDisplay : ScriptableObject
	{
		public Sprite normal;
		public Sprite wet;
		public Sprite dry;
	}
}