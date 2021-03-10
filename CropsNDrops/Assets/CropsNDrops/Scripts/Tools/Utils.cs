using UnityEngine;

namespace CropsNDrops.Scripts.Tools
{
	public class Utils : MonoBehaviour
	{
		public static GameObject GetRaycastHitObject(Vector3 eventData, bool hitUIObject = false, bool debugRay = false)
		{
			if (hitUIObject)
			{
				eventData = WorldToScreenPoint(eventData);
			}
			
			Ray ray = GameManager.Instance.Camera.ScreenPointToRay(eventData);

			if (debugRay)
			{
				Debug.DrawRay(ray.origin, ray.direction * 100, Color.magenta);
			}

			if (!Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, float.PositiveInfinity))
			{
				return null;
			}
			
			Collider hitCollider = hit.collider;
			GameObject hitObject = hitCollider.gameObject;

			return hitObject;
		}

		public static Vector3 Centralize(Vector3 parent, Vector3 position)
		{
			Vector3 updatedPosition = position;
			updatedPosition += (parent - updatedPosition) * (5 * Time.deltaTime);
			
			return updatedPosition;
		}

		public static Vector3 ScreenToWorldPoint(Vector2 screenPosition, bool is2D = true)
		{
			Camera cam = GameManager.Instance.Camera;
			Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cam.nearClipPlane);
			Vector3 wordlCoordinates = cam.ScreenToWorldPoint(screenCoordinates);
			
			if (is2D)
			{
				wordlCoordinates.z = 0;
			}

			return wordlCoordinates;
		}
		
		public static Vector3 WorldToScreenPoint(Vector3 worldPosition)
		{
			Camera cam = GameManager.Instance.Camera;
			Vector3 screenCoordinates = cam.WorldToScreenPoint(worldPosition);
			
			return screenCoordinates;
		}
	}
}