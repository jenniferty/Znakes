using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    void Start(){
        Invoke("Explode", 5f);
    }

    void Explode(){
        gameObject.SetActive(false);
    }
}
