using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class ActiveWeapon : MonoBehaviour
{
    public Transform crossHairTarget;
    public UnityEngine.Animations.Rigging.Rig handIk;
    raycastWeapon weapon;

    public Transform weaponParent;

    public Transform weaponLeftGrip;
    public Transform weaponRightGrip;

    Animator anim;
    AnimatorOverrideController overrides;

    void Start()
    {
        anim = GetComponent<Animator>();
        overrides = anim.runtimeAnimatorController as AnimatorOverrideController;
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
        else
        {
            handIk.weight = 0.0f;
            anim.SetLayerWeight(1, 0.0f);
        }
    }

    public void Equip(raycastWeapon newWeapon) {
        if (weapon)
        {
            Destroy(weapon.gameObject);
        }


        weapon = newWeapon;
        weapon.raycastDestination = crossHairTarget;
        weapon.transform.parent = weaponParent;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        handIk.weight = 1.0f;
        anim.SetLayerWeight(1, 1.0f);

        Invoke(nameof(SetAnimationDelayed), 0.001f);

        
    }


    void SetAnimationDelayed()
    {
        overrides["weapon_anim_empty"] = weapon.weaponAnimation;
    }

    [ContextMenu("Save weapon pose")]
    void SaveWeaponPose()
    {
        GameObjectRecorder recorder = new GameObjectRecorder(gameObject);
        recorder.BindComponentsOfType<Transform>(weaponParent.gameObject, false);
        recorder.BindComponentsOfType<Transform>(weaponLeftGrip.gameObject, false);
        recorder.BindComponentsOfType<Transform>(weaponRightGrip.gameObject, false);
        recorder.TakeSnapshot(0.0f);
        recorder.SaveToClip(weapon.weaponAnimation);

        UnityEditor.AssetDatabase.SaveAssets();
    
    
    }
        
    
}
