using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLimb : MonoBehaviour
{
    [SerializeField] private Transform target;
    private ConfigurableJoint configurableJoint;
    Quaternion initial;

    void Start()
    {
        this.configurableJoint = this.GetComponent<ConfigurableJoint>();
        this.initial = this.target.transform.localRotation;
    }

    private void FixedUpdate()
    {
        configurableJoint.targetRotation = copyLimb();
    }

    private Quaternion copyLimb()
    {
        return Quaternion.Inverse(this.target.localRotation) * this.initial;
    }

}
