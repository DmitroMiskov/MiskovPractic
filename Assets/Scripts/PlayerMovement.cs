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
    private Vector2 direction;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        Move(direction);
    }

    public void Move(Vector2 moveDirection)
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if(direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(moveDirection);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    private void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }

    private void SetAnimatorMovement(Vector2 moveDirection)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("xDir", moveDirection.x);
        animator.SetFloat("yDir", moveDirection.y);
        /*Debug.Log(animator.GetFloat("xDir"));*/
    }
}
