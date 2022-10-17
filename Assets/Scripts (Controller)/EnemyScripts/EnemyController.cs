using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    public ObjectSpawnLocation enemySpawnLocation;

    public GameObject bomb_Pickup;
    public GameObject health_Pickup;
    public GameObject enemy_Pickup;
    public GameObject speedPowerup_Pickup;
    public float[,] coordinates;

    //bounds for area for bomb to spawn
    //values for testing only
    private float min_X, max_X, min_Z, max_Z, y_Pos;
    //for collision check
    private float radiusCheck = 2f;

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
        if (instance == null)
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

    public void RandomiseLocation()
    {
        coordinates = enemySpawnLocation.getCoordinates();
        int area = Random.Range(1, coordinates.GetLength(0));
        setMin_X(coordinates[area, 0]);
        setMax_X(coordinates[area, 1]);
        setMin_Z(coordinates[area, 2]);
        setMax_Z(coordinates[area, 3]);
        setY_Pos(coordinates[area, 4]);
    }

    IEnumerator SpawnPickUps()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        RandomiseLocation();
        if (Random.Range(0, 10) >= 2)
        {
            Vector3 pos = new Vector3(Random.Range(getMin_X(), getMax_X()), getY_Pos(), Random.Range(getMin_Z(), getMax_Z()));
            bool check = CollisionCheck(pos);
            if (check)
            {
                if (Random.Range(0, 10) >= 3)
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
            Vector3 pos = new Vector3(Random.Range(getMin_X(), getMax_X()), getY_Pos(), Random.Range(getMin_Z(), getMax_Z()));
            bool check = CollisionCheck(pos);
            if (check)
            {
                if (Random.Range(0, 10) >= 4)
                {
                    Instantiate(health_Pickup, pos, Quaternion.identity);
                }
                else
                {
                    Instantiate(speedPowerup_Pickup, pos, Quaternion.identity);
                    Debug.Log("speedPowerup spawned");
                }
            }
        }
        Invoke("StartSpawning", 0f);
    }

    private void Update()
    {

        if (Input.GetKeyDown("t"))
        {
            Vector3 pos = new Vector3(Random.Range(getMin_X(), getMax_X()), getY_Pos(), Random.Range(getMin_Z(), getMax_Z()));
            Instantiate(speedPowerup_Pickup, pos, Quaternion.identity);
            Debug.Log("speedPowerup spawned");
        }
    }

    public bool CollisionCheck(Vector3 pos)
    {
        Collider[] colliders = Physics.OverlapSphere(pos, getRadiusCheck());
        foreach (Collider col in colliders)
        {
            //change/add new tags as needed
            if (col.tag == "Bomb" || col.tag == "Player" || col.tag == "Sides" || col.tag == "Food" || col.tag == "Health" || col.tag == "Enemy" || col.tag == "SpeedPowerup")
            {
                return false;
            }
        }
        return true;
    }

    public float getMin_X()
    {
        return this.min_X;
    }
    public void setMin_X(float min_X)
    {
        this.min_X = min_X;
    }
    public float getMax_X()
    {
        return this.max_X;
    }
    public void setMax_X(float max_X)
    {
        this.max_X = max_X;
    }
    public float getMin_Z()
    {
        return this.min_Z;
    }
    public void setMin_Z(float min_Z)
    {
        this.min_Z = min_Z;
    }
    public float getMax_Z()
    {
        return this.max_Z;
    }
    public void setMax_Z(float max_Z)
    {
        this.max_Z = max_Z;
    }
    public float getY_Pos()
    {
        return this.y_Pos;
    }
    public void setY_Pos(float y_Pos)
    {
        this.y_Pos = y_Pos;
    }
    public float getRadiusCheck()
    {
        return this.radiusCheck;
    }
}