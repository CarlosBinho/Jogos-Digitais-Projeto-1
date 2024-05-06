using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverParaDireita : MonoBehaviour
{

    public float velocidade = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);
    }
}
