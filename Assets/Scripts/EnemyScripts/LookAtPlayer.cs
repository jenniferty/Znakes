using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Camera target;
    void Start()
    {
        target = GameObject.Find("Target Camera").GetComponent<Camera>();
    }
    void Update()
    {
        transform.LookAt(transform.position + target.transform.rotation * Vector3.forward, target.transform.rotation * Vector3.up);
    }
}
