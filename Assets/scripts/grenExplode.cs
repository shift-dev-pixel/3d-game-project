using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenExplode : MonoBehaviour
{
    public float delay = 3f;
    public float blastRadius = 5f;
    public GameObject explosionEffect;

    float cuntdown;
    bool exploded = false;

    private void Start()
    {
        cuntdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        cuntdown -= Time.deltaTime;
        Debug.Log("Countdown: "+ cuntdown);
        if (cuntdown <= 0f && !exploded)
        {
            Explode();
            exploded = true;
        }
    }

    private void Explode()
    {
        Debug.Log("Explode called");
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in colliders) { 
            Target health = nearbyObject.GetComponent<Target>();
            if (health != null)
            {
                health.TakeDamage(50);
            }
        }

        Destroy(gameObject);
    }
}
