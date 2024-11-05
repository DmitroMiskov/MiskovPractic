using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IMover
{
    void Move(Vector2 direction);
}

public class PlayerMovement : MonoBehaviour, IMover
{
    public float speed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Move(Vector2 moveDirection)
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            SetAnimatorMovement(moveDirection);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    private void SetAnimatorMovement(Vector2 moveDirection)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("xDir", moveDirection.x);
        animator.SetFloat("yDir", moveDirection.y);
    }
}
