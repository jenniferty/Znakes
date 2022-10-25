using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject bomb;
    private float radius;
    private float power;
    private float upForce;
    public GameObject explosionPrefab;
    private float bombTimer;

    // Start is called before the first frame update
    void Start()
    {
        setRadius(5f);
        setPower(3f);
        setUpForce(0f);
        setBombTimer(Random.Range(4, 8));
    }

    // Update is called once per frame
    void Update()
    {
        if (bomb == enabled)
        {
            if (getBombTimer() > 0)
            {
                setBombTimer(getBombTimer() - Time.deltaTime);
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

    public void Detonate()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, getRadius());
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(getPower(), explosionPosition, getRadius(), getUpForce(), ForceMode.Impulse);
            }
            //hit per particle
            PlayerHealthController playerHealth = hit.GetComponent<PlayerHealthController>();
            if (playerHealth != null)
            {
                playerHealth.GetComponent<PlayerHealthController>().TakeDamage(5);
            }
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("BombExplosion");
        }
    }
    public float getRadius()
    {
        return this.radius;
    }
    public void setRadius(float radius)
    {
        this.radius = radius;
    }
    public float getPower()
    {
        return this.power;
    }
    public void setPower(float power)
    {
        this.power = power;
    }
    public float getUpForce()
    {
        return this.upForce;
    }
    public void setUpForce(float upForce)
    {
        this.upForce = upForce;
    }
    public float getBombTimer()
    {
        return this.bombTimer;
    }
    public void setBombTimer(float bombTimer)
    {
        this.bombTimer = bombTimer;
    }
}
