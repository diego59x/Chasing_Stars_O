using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject referenceToFollow;
    private Vector3 distVec;
    
    void Start()
    {
        if (referenceToFollow)
            distVec = referenceToFollow.transform.position - transform.position;
    }
    private void FixedUpdate()
    {
        if (referenceToFollow)
            transform.position = referenceToFollow.transform.position - distVec;
    }
}
