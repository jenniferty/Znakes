/*
Code copied from https://weeklyhow.com/unity-minimap-in-10-minutes/
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 playerPosition = _player.position;
        playerPosition.y = transform.position.y;
        transform.position = playerPosition;

        //map rotate with player
        transform.rotation = Quaternion.Euler(90f, _player.eulerAngles.y, 0f);
    }
}