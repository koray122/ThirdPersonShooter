using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomation : MonoBehaviour
{
    Animator animator;
    Vector2 input;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Horizontal ve Vertical inputlar� al�yoruz
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        // Animasyon parametrelerine input de�erlerini g�nderiyoruz
        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);
    }
}
