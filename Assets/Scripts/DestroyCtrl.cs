using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCtrl : MonoBehaviour
{
    public bool isDestroy = false;
    void Update()
    {
        if(isDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}

