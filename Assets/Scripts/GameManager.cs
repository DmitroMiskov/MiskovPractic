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

        Vector2 inputDirection = _playerController.TakeInput();
        if (inputDirection != Vector2.zero)
        {
            _playerMovement.Move(inputDirection);
        }
    }
}
