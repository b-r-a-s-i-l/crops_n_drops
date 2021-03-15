using UnityEngine;

namespace CropsNDrops.Scripts.Scriptables.Garden
{
	[CreateAssetMenu(fileName = "New Fences", menuName = "Fences of Garden", order = 0)]
	public class FenceDisplay : ScriptableObject
	{
		public Sprite topLeft = default;
		public Sprite topMiddle =  default;
		public Sprite topRight =  default;
		public Sprite left =  default;
		public Sprite right =  default;
		public Sprite bottomLeft =  default;
		public Sprite bottomMiddle =  default;
		public Sprite bottomRight =  default;
	}
}