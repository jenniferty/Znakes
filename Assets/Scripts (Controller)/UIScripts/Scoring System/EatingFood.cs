using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script updates score
public class EatingFood : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        ScoreCounter.score += 50;
        Destroy(gameObject);
    }
}
