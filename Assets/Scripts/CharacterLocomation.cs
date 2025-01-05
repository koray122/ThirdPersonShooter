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
        // Horizontal ve Vertical inputlarý alýyoruz
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        // Animasyon parametrelerine input deðerlerini gönderiyoruz
        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);
    }
}
