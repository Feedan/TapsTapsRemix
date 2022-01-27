using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    public Transform Target, SelfTransform;

    private void LateUpdate()
    {
        SelfTransform.position = Target.position + new Vector3(-5, 4, 0);
    }
}
