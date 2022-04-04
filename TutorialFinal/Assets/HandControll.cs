using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class HandControll : MonoBehaviour
{
    public ActionBasedController CameraController;
    public ActionBasedController RightHandController;
    public ActionBasedController LeftHandController;

    public GameObject Physics;
    public GameObject Modell;
    public GameObject Head;
    public GameObject Camera;

    public GameObject RTarget;
    public GameObject LTarget;

    private Vector3 _camPos;

    private Vector3 _rHandPos;
    private Vector3 _lHandPos;

    private Quaternion _rHandRot;
    private Quaternion _lHandRot;

    void Update()
    {
        inputs();

        Modell.transform.position = Physics.transform.position;
        Camera.transform.position = Head.transform.position;

        RTarget.transform.position = Head.transform.position + (_rHandPos - _camPos);
        LTarget.transform.position = Head.transform.position + (_lHandPos - _camPos);

        RTarget.transform.rotation = _rHandRot;
        LTarget.transform.rotation = _lHandRot;
    }
    void inputs()
    {
        _camPos = CameraController.positionAction.action.ReadValue<Vector3>();

        _rHandPos = RightHandController.positionAction.action.ReadValue<Vector3>();
        _rHandRot = RightHandController.rotationAction.action.ReadValue<Quaternion>();

        _lHandPos = LeftHandController.positionAction.action.ReadValue<Vector3>();
        _lHandRot = LeftHandController.rotationAction.action.ReadValue<Quaternion>();
    }
}
