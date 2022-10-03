using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{
    [Tooltip("The target to be tracked.")]
    [SerializeField] private Transform target;
    [Tooltip("The offset position from the target.")]
    [SerializeField] private Vector3 positionOffset;

    /// <summary>
    /// LateUpdate is called at the end of every frame update
    /// </summary>
    void LateUpdate()
    {
        transform.position = target.position + positionOffset;
    }
}
