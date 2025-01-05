using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AktifWeapon : MonoBehaviour
{
    public Transform crossHairTarget;
    public raycastWeapon weapon;

    void Start()
    {
        raycastWeapon existingWeapon = GetComponentInChildren<raycastWeapon>();
        if (existingWeapon)
        {
            Equip(existingWeapon);
        }
    }


    void Update()
    {
        if (weapon)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.StartFiring();
            }
            if (weapon.isFiring)
            {
                weapon.UpdateFiring(Time.deltaTime);
            }

            weapon.UpdateBullets(Time.deltaTime);

            if (Input.GetButtonUp("Fire1"))
            {
                weapon.StopFiring();
            }
        }
    }

    public void Equip(raycastWeapon newWeapon)
    {
        weapon = newWeapon;
        weapon.raycastDestination = crossHairTarget;
    }
}
