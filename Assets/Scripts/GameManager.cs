using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private PlayerController _playerController;
    private IMover _playerMovement;

    [Inject]
    private void Construct(PlayerController playerController, IMover playerMovement)
    {
        _playerController = playerController;
        _playerMovement = playerMovement;
    }

    private void Update()
    {
        _playerController.HandleInput();
        Vector2 inputDirection = TakeInput();
        _playerMovement.Move(inputDirection);
    }

    private Vector2 TakeInput()
    {
        Vector2 direction = Vector2.zero;

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

        return direction;
    }
}
