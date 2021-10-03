using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform TargetObject;        //�ǂ�������I�u�W�F�N�g

    [SerializeField] private float CameraDistance = 3.0f;   // �v���C���[�Ƃ̋���
    [SerializeField] private float Height = 1.0f;           //�J�����̍���
    [SerializeField] private float SmoothSpeed = 2.5f;      //�J�����̒ǂ��t�����x

    [SerializeField] private Camera Player_Camera;
    private void Awake()
    {
        var Position = TargetObject.position + new Vector3(0.0f, Height, -CameraDistance);
        Player_Camera = GameObject.Find("Player_Track_Camera").GetComponent<Camera>();
        Player_Camera.transform.position = Position;
    }
    void Update()
    {
        CameraPlayerSmoothTracker();
    }

    void CameraPlayerSmoothTracker()
    {
        var Position = TargetObject.position + new Vector3(0.0f, Height, -CameraDistance);
        Player_Camera.transform.position = Vector3.Lerp(Player_Camera.transform.position, Position, Time.deltaTime * SmoothSpeed);
    }
}
