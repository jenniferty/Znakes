using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crawlerScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float crawlSpeed = 50f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Camera.main.transform.up * crawlSpeed * Time.deltaTime);
    }
}
