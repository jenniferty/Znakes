using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
   public static GameplayController instance;

   public GameObject bomb_Pickup;

    //bounds for area for bomb to spawn
    //values for testing only
   private float min_X = -5f, max_X = 5f, min_Z = -5f, max_Z = 5f;
   private float yPos = 2.92f;
   /*
   public GameObject level;
   int[,] area = level.getSpawnArea();

   public var RandomiseSpawnPoint(int[,] area){
    int rowSize = area.GetLength(0);
    int row = Random.Range(0, rowSize-1);
    min_X = area[row, 0];
    max_X = area[row, 1];
    min_Z = area[row, 2];
    max_Z = area[row, 3];
    yPos = area[row, 4];
    var pos = new Vector3(Random.Range(min_X, max_X), yPos, Random.Range(min_Z, max_Z))
    return pos;
   }
   */

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

   //getandsetdifficultysetting which affects enemy spawn rate

   //

   //able to set frequency of enemy spawning and time limit to increase difficulty
   IEnumerator SpawnPickUps(){
    yield return new WaitForSeconds(Random.Range(1f, 6f));
    if(Random.Range(0, 10) >= 2){
        var pos = new Vector3(Random.Range(min_X, max_X), yPos, Random.Range(min_Z, max_Z));
        Instantiate(bomb_Pickup, pos, Quaternion.identity);
    }else{
        //do later
    }
    Invoke("StartSpawning", 0f);
   }
   /*
   IEnumerator SpawnPickUps(){
    yield return new WaitForSeconds(Random.Range(1f, 3f));
    if(Random.Range(0, 10) >= 2){
        var pos = new RandomiseSpawnPoint(area);
        Instantiate(bomb_Pickup, pos, Quaternion.identity);
    }else{
        //do later
    }
    Invoke("StartSpawning", 0f);
   }
   */
}
