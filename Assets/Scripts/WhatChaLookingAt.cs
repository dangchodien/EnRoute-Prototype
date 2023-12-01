using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatChaLookingAt : MonoBehaviour
{
    public Transform ThingToLookAt;

    void FixedUpdate()
    {
        transform.LookAt(ThingToLookAt.transform.position);
    }
}
