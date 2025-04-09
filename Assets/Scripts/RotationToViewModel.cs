using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationToViewModel : MonoBehaviour
{
    public float angular_speed = 40;
    void Update()
    {
        transform.Rotate(new Vector3(0, angular_speed, 0) * Time.deltaTime);
    }
}
