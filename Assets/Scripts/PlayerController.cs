using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private readonly Player _player;

    public PlayerController(Player player)
    {
        _player = player;
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.Shoot();
        }
    }
}
