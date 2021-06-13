﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class CharacterControl : MonoBehaviour
{

    [SerializeField] int moveSpeed;
    [SerializeField] int jumpHeight;

    //private CharacterController charController;
    private Rigidbody charRigidBody;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        charRigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveChar = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += moveChar * Time.deltaTime * moveSpeed;
        //charController.SimpleMove(moveChar * moveSpeed);

        if (charRigidBody.velocity.magnitude == 0)
        {
            anim.SetBool("isWalking", false);
        } else
        {
            anim.SetBool("isWalking", true);
        }

    }
}
