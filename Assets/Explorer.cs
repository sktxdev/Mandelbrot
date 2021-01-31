using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorer : MonoBehaviour
{
    public Material mat;
    public Vector2 pos;
    public float scale;
    public float speed;


    private Vector2 smoothPos;
    private float smoothScale;


    public int counter = 0;

    private void UpdateShader() {

        // Smooth positioning and scaling
        // Lerp means move from pos to smoothPos in 30% increments
        smoothPos = Vector2.Lerp(smoothPos, pos, 0.3f);
        smoothScale = Mathf.Lerp(smoothScale, scale, 0.03f);


        float aspect = (float)Screen.width / (float)Screen.height;
        float scaleX = smoothScale;
        float scaleY = smoothScale;




        if (aspect > 1.0f)
        {
            scaleY /= aspect;
        }
        else
        {
            scaleX *= aspect;
        }

        mat.SetVector("_Area", new Vector4(smoothPos.x, smoothPos.y, scaleX, scaleY));
    }

    void FixedUpdate()
    {
        HandleInput();
        HandlePanning();
        UpdateShader();
    }

    private void HandleInput() {
        if (Input.GetKey(KeyCode.KeypadPlus))
            scale *= 0.99f;

        if (Input.GetKey(KeyCode.KeypadMinus))
            scale *= 1.01f;
    }

    private void HandlePanning()
    {
        // RIGHT
        if (Input.GetKey(KeyCode.D))
        {
            pos.x -= .01f * scale;
        }

        // LEFT
        if (Input.GetKey(KeyCode.A))
        {
            pos.x += 0.01f * scale;
        }

        // UP
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += 0.01f * scale;
        }

        // DOWN
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= .01f * scale;
        }

    }

}
