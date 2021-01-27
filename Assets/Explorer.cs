using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorer : MonoBehaviour
{
    public Material mat;
    public Vector2 pos;
    public float scale;

    public int counter = 0;

    private void UpdateShader() {

        float aspect = (float)Screen.width / (float)Screen.height;
        float scaleX = scale;
        float scaleY = scale;


        if (aspect > 1.0f)
        {
            scaleY /= aspect;
        }
        else
        {
            scaleX *= aspect;
        }

        mat.SetVector("_Area", new Vector4(pos.x, pos.y, scaleX, scaleY));
    }

    void FixedUpdate()
    {
        HandleInput();
        UpdateShader();

    }

    private void HandleInput() {
        if (Input.GetKey(KeyCode.KeypadPlus))
            scale *= 0.99f;
        
        if (Input.GetKey(KeyCode.KeypadMinus))
            scale *= 1.01f;

    }



}
