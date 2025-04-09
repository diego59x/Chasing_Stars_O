using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    private ReferenceCameraMovement referenceCamera;
    public Movimiento movimientoPlayer;

    public Image foregroundProgressBar;
    public Gradient progressGradient;
    private float currentTime = 0;
    private float fill = 0;
    private float percentage = 0;
    public float lifetime = 5f;

    private void Start()
    {
        referenceCamera = GetComponentInParent<ReferenceCameraMovement>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        percentage = (lifetime - currentTime) / lifetime;
        fill = currentTime / lifetime;

        foregroundProgressBar.fillAmount = fill;
        foregroundProgressBar.color = progressGradient.Evaluate(percentage);

        if (Input.GetKeyDown(KeyCode.Space))
            ButtonBoost();
    }

    public void ButtonBoost()
    {
        if (fill > 0.95f)
        {
            referenceCamera.ButtonBoost();
            movimientoPlayer.ButtonBoost();
            currentTime = 0;
            fill = 0;
            percentage = 0;
        }

    }
}
