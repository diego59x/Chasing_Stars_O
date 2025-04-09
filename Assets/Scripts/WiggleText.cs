using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WiggleText : MonoBehaviour
{
    TMP_Text textMesh;
    Mesh mesh;
    Vector3[] vertices;
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = Wobble(Time.time + i);

            vertices[i] = vertices[i] + offset;
        }
        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }

    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * 9.3f), Mathf.Cos(time * 6.8f));
    }
}
