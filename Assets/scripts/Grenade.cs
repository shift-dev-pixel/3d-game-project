using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeLauncher : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform firePoint;
    public float minLaunchForce = 10f;
    public float maxLaunchForce = 50f;
    public float maxChargeTime = 2f;
    public float cooldownTime = 3f;
    public Image cooldownBar; // Ссылка на UI-элемент полосы перезарядки
    public Image chargeBar;

    private bool isCharging = false;
    private float chargeStartTime;
    private float lastShotTime;
    private bool isOnCooldown = false;

    void Update()
    {
        // Обновляем полосу перезарядки
        if (isOnCooldown)
        {
            float cooldownRatio = (Time.time - lastShotTime) / cooldownTime;
            cooldownBar.fillAmount = cooldownRatio; // Обновляем полосу перезарядки

            if (cooldownRatio >= 1f)
            {
                isOnCooldown = false; // Снимаем кулдаун
                cooldownBar.fillAmount = 1f; // Полоса полностью заполнена
            }
            return;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            StartCharging();
        }

        if (Input.GetButtonUp("Fire2") && isCharging)
        {
            LaunchGrenade();
        }
    }

    void StartCharging()
    {
        isCharging = true;
        chargeStartTime = Time.time;
        chargeBar.fillAmount = 0f;
    }

    void LaunchGrenade()
    {
        float chargeDuration = Time.time - chargeStartTime;
        float chargeRatio = Mathf.Clamp01(chargeDuration / maxChargeTime);
        float launchForce = Mathf.Lerp(minLaunchForce, maxLaunchForce, chargeRatio);

        GameObject grenade = Instantiate(grenadePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * launchForce, ForceMode.Impulse);

        isCharging = false;
        lastShotTime = Time.time;
        isOnCooldown = true;
        cooldownBar.fillAmount = 0f; // Сбрасываем полосу перезарядки
    }
}