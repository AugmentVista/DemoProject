using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBlend : MonoBehaviour
{
    public PlayerLocomotionHandler playerMove;
    public Animator animator;
    public GameObject player;

    float movement;
    void Start()
    {
        player.SetActive(true);
        animator = gameObject.GetComponent<Animator>();
        movement = PlayerLocomotionHandler.moveSpeed;
        animator.SetFloat("speed", movement);
    }

    void Update()
    {
        movement = PlayerLocomotionHandler.moveSpeed;
        animator.SetFloat("speed", movement);
    }
}
