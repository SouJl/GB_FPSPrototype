using FPS_Game.MVC;
using UnityEditor;
using UnityEngine;

namespace FPS_Game
{
    [CustomEditor(typeof(FieldOfView))]
    public class FieldOfViewEditor: Editor
    {
        private void OnSceneGUI()
        {
            FieldOfView fov = (FieldOfView)target;
            Handles.color = Color.yellow;
            Handles.DrawWireArc(fov.PointofView.position, Vector3.up, fov.transform.forward, fov.Angle / 2, fov.Distance);
            Handles.DrawWireArc(fov.PointofView.position, Vector3.up, fov.transform.forward, -fov.Angle / 2, fov.Distance);

            Vector3 viewAngle01 = DirectionFromAngle(fov.PointofView.eulerAngles.y, -fov.Angle / 2);
            Vector3 viewAngle02 = DirectionFromAngle(fov.PointofView.eulerAngles.y, fov.Angle / 2);

            Handles.color = Color.yellow;
            Handles.DrawLine(fov.PointofView.position, fov.PointofView.position + viewAngle01 * fov.Distance);
            Handles.DrawLine(fov.PointofView.position, fov.PointofView.position + viewAngle02 * fov.Distance);
        }

        private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
        {
            angleInDegrees += eulerY;

            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
    }
}
