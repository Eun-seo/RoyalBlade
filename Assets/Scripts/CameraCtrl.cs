using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform Player;
    public Transform Camera;
    private void Awake()
    {
        
    }
    void Update()
    {
        Vector3 pos = Camera.position;
        pos.y = Player.position.y;
        if (pos.y >= 1)
        {
            Camera.position = pos;
        }
        
    }
}
