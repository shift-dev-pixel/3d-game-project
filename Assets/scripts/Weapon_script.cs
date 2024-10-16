using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_script : MonoBehaviour
{
    public float damage = 10f;
    public float range = 300f;

    public Camera fpsCam;
    public ParticleSystem flash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
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
        }
    }
}
