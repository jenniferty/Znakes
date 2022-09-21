using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
   public static EnemyController instance;

   public GameObject bomb_Pickup;

    //bounds for area for bomb to spawn
    //values for testing only
   private float min_X = -15f, max_X = 15f, min_Z = -15f, max_Z = 15f;
   private float yPos = 2.92f;

   //for collision check
   public float radiusCheck = 2f;
   
   void Awake(){
    MakeInstance();
   }

   void Start(){
    Invoke("StartSpawning", 1f);
   }

   void MakeInstance(){
    if(instance == null){
        instance = this;
    }
   }

   void StartSpawning(){
    StartCoroutine(SpawnPickUps());
   }

   public void CancelSpawning(){
    CancelInvoke("StartSpawning");
   }

   IEnumerator SpawnPickUps(){
    yield return new WaitForSeconds(Random.Range(1f, 3f));
    if(Random.Range(0, 10) >= 2){
        Vector3 pos = new Vector3(Random.Range(min_X, max_X), yPos, Random.Range(min_Z, max_Z));
        bool check = CollisionCheck(pos);
        if(check)
        {
            Instantiate(bomb_Pickup, pos, Quaternion.identity);
        }
    }else{
        //do later
    }
    Invoke("StartSpawning", 0f);
   }

   public bool CollisionCheck(Vector3 pos)
   {
        Collider[] colliders = Physics.OverlapSphere(pos, radiusCheck);
        foreach(Collider col in colliders)
        {
            //change/add new tags as needed
            if(col.tag == "Bomb" || col.tag == "Player" || col.tag == "Sides" || col.tag == "Food")
            {
                return false;
            }               
        }
        return true;     
   }
}
