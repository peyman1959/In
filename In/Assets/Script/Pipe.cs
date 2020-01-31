using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public List<Rigidbody> rb;
    public Vector3 dir;
    public float power;
    private void OnMouseDown()
    {
        foreach (Rigidbody rigidbody in rb)
        {
            rigidbody.AddForce(dir*power);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        rb.Add(other.GetComponent<Rigidbody>());
    }

    private void OnTriggerExit(Collider other)
    {
        rb.Remove(other.GetComponent<Rigidbody>());
    }
}
