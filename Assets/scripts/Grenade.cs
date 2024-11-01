using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform grenadeSpawn;
    public float gremadeVelocity = 10f;
    public float grenadePrefabLifetime = 10f;
    public float grenadeCooldown = 3f;
    private float lastUsedTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time > lastUsedTime + grenadeCooldown)
        {
            fireWeapon();
            lastUsedTime = Time.time;
        }
    }

    private void fireWeapon()
    {
        GameObject grenade = Instantiate(grenadePrefab, grenadeSpawn.position, Quaternion.identity);

        grenade.GetComponent<Rigidbody>().AddForce(grenadeSpawn.forward.normalized * gremadeVelocity, ForceMode.Impulse);
    }
}
