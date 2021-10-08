using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform TargetObject;        //追いかけるオブジェクト

    [SerializeField] private float CameraDistance = 3.0f;   // プレイヤーとの距離
    [SerializeField] private float Height = 1.0f;           //カメラの高さ
    [SerializeField] private float SmoothSpeed = 2.5f;      //カメラの追い付く速度

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
