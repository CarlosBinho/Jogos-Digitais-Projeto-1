using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    public string _tagTargetDetection = "Player";

    public List<Collider2D> detectedObjs = new List<Collider2D>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == _tagTargetDetection)
        {
            detectedObjs.Add(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _tagTargetDetection && !detectedObjs.Contains(collision))
        {
            detectedObjs.Add(collision);
        }
    }

}
