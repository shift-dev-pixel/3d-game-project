using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_script : MonoBehaviour
{
    public float damage = 1f;
    public float range = 300f;
    public float fireRate = 20f;

    public Camera fpsCam;
    public ParticleSystem flash;
    public GameObject impact;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        flash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null )
            {
                target.TakeDamage(damage);
            }

            GameObject impactGo = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 0.2f);
        }
    }
}
