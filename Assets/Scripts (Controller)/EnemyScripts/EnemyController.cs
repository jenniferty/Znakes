using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
   public static EnemyController instance;

   public GameObject bomb_Pickup;
   public GameObject health_Pickup;
   public GameObject enemy_Pickup;

    //bounds for area for bomb to spawn
    //values for testing only
   private float min_X = -25f, max_X = 25f, min_Z = -25f, max_Z = 25f;
   private float yPos = 3.8f;

   //for collision check
   public float radiusCheck = 2f;

   void Awake()
   {
        MakeInstance();
   }

   void Start()
   {
        Invoke("StartSpawning", 1f);
   }

   void MakeInstance()
   {
        if(instance == null)
        {
            instance = this;
        }
   }

   void StartSpawning()
   {
        StartCoroutine(SpawnPickUps());
   }

   public void CancelSpawning()
   {
        CancelInvoke("StartSpawning");
   }

   IEnumerator SpawnPickUps()
   {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        if(Random.Range(0, 10) >= 2)
        {
            Vector3 pos = new Vector3(Random.Range(min_X, max_X), yPos, Random.Range(min_Z, max_Z));
            bool check = CollisionCheck(pos);
            if(check)
            {
                if(Random.Range(0, 10) >= 3)
                {
                    Instantiate(bomb_Pickup, pos, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemy_Pickup, pos, Quaternion.identity);
                }
            
            }
        }
        else
        {
            Vector3 pos = new Vector3(Random.Range(min_X, max_X), yPos, Random.Range(min_Z, max_Z));
            bool check = CollisionCheck(pos);
            if(check)
            {
                Instantiate(health_Pickup, pos, Quaternion.identity);
            }
        }
        Invoke("StartSpawning", 0f);
   }

   public bool CollisionCheck(Vector3 pos)
   {
        Collider[] colliders = Physics.OverlapSphere(pos, radiusCheck);
        foreach(Collider col in colliders)
        {
            //change/add new tags as needed
            if(col.tag == "Bomb" || col.tag == "Player" || col.tag == "Sides" || col.tag == "Food" || col.tag == "Health" || col.tag == "Enemy")
            {
                return false;
            }               
        }
        return true;     
   }
}
