using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceCameraMovement : MonoBehaviour
{
    public float speed;
    public float min_distToIncrease = 10;

    private void Update()
    {
        if (transform.position.z > min_distToIncrease)
            speed += 0.001f;
    }
    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    public void ButtonBoost()
    {
        transform.Translate(Vector3.forward * 8);
    }
}
