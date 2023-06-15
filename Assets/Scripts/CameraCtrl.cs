using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform Player;
    public Transform Camera;
    void Update()
    {
        //카메라 플레이어 따라가기
        Vector3 pos = Camera.position;
        pos.y = Player.position.y;

        if (pos.y >= 1)
        {
            Camera.position = pos;
        }
        
    }
}
