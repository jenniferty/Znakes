using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject bomb;
    public float radius = 3f;
    public float power = 3f;
    public float upforce = 0f;
    public GameObject explosionPrefab;
    public float bombTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bomb == enabled)
        {
            if (bombTimer > 0)
            {
                bombTimer -= Time.deltaTime;
            }
            else{
                Invoke("Detonate", 0);
            }
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        Detonate();
    }

    void Detonate()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
            //hit per particle
            PlayerController player = hit.GetComponent<PlayerController>();
            if (player != null)
            {
                player.GetComponent<PlayerController>().TakeDamage(5);
                Debug.Log(player.health);
            }
            Destroy(gameObject);
        }

    }
}
