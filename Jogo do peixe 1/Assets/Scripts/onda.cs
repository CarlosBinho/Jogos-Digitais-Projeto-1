using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onda : MonoBehaviour
{

    public float vel = 20.0f;
    public Renderer quad;

    // Start is called before the first frame update
    void Start()
    {
        vel = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2 (vel * Time.deltaTime, 0);
        quad.material.mainTextureOffset += offset;

    }
}
