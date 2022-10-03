using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 positionOffSet;

    private void LateUpdate()
    {
        transform.position = target.position + positionOffSet;
    }


}
