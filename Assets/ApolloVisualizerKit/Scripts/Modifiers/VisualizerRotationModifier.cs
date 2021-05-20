using UnityEngine;
using System.Collections;
namespace Apollo
{
    [AddComponentMenu("Apollo/Modifiers/Rotation Modifier")]
    public class VisualizerRotationModifier : VisualizerObjectBase
    {
        public Vector3 RotationAxes;
        public float RotationSpeed;
        void ChangeRotation()
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles,transform.rotation.eulerAngles+ RotationAxes*modifier,modifier*RotationSpeed));
        }
        void Update()
        {
            EvaluateRange();
            ChangeRotation();
        }
    }
}
