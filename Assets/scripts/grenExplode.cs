using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenExplode : MonoBehaviour
{
    public float delay = 3f;
    public float blastRadius = 5f;
    public GameObject explosionEffect;

    float countdown;
    bool exploded = false;

    private void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        Debug.Log("Countdown: "+ countdown);
        if (countdown <= 0f && !exploded)
        {
            Explode();
            exploded = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Explode immediately upon touching any surface
        if (!exploded)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("Explode called");
        GameObject ExplosionEff = Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in colliders) { 
            EnemyHealth health = nearbyObject.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(50);
            }
        }

        Destroy(gameObject);
        Destroy(ExplosionEff, 2f);
    }
}
