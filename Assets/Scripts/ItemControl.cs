using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemControl : MonoBehaviour
{
    public void OnUserAction()
    {
        Debug.Log("アイテムです");
        
    }
}
