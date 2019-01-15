using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Items : MonoBehaviour
{
    public int ID;
    public string Name;
    public Sprite texture;

    private Rigidbody rb;
    public bool bApplyPhysics;
    public bool bPlaced;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!bApplyPhysics && bPlaced)
        {
            Destroy(rb);
        }
    }
}
