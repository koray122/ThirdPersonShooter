using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterAiming : MonoBehaviour
{
    public float turnSpeed = 15f;
    Camera mainCamera;
    public Rig aimLayer;
    public float aimDuraction = 0.3f;

    


    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {

        if (aimLayer)
        {
            //if (Input.GetButton("Fire2"))
            //{
            //    aimLayer.weight += Time.deltaTime / aimDuraction;

            //}
            //else
            //{
            //    aimLayer.weight -= Time.deltaTime / aimDuraction;
            //}

            aimLayer.weight = 1.0f;
        }

    }

}