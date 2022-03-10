using UnityEngine;

namespace DataVisualisation
{
    public class GravityGizmo : MonoBehaviour
    {
        private void Update()
        {
            if (GameManager.CurrentSensorData == null)
                return;
        
            if (!GameManager.CurrentSensorData.attitudeData.HasValue)
                return;

            var attitude = GameManager.CurrentSensorData.attitudeData.Value;
            var rotation = LeftToRightHandedRotation(attitude);
            transform.rotation = rotation;
        }

        private static Quaternion LeftToRightHandedRotation(Quaternion q)
        {
            return new Quaternion(q.x, q.y, -q.z, q.w);
        }
    }
}