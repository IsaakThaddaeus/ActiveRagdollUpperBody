using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public ActionBasedController CameraController;
    private Quaternion _camRot;

    public GameObject Body;
    public GameObject Modell;

    void Update()
    {
        _camRot = CameraController.rotationAction.action.ReadValue<Quaternion>();

        Modell.transform.rotation = Quaternion.Euler(0, _camRot.eulerAngles.y, 0);
        Body.transform.rotation = Quaternion.Euler(0, _camRot.eulerAngles.y, 0);
    }


}
