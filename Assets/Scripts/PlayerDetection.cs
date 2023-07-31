using System;
using Zenject;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private Transform _playerPosition;

    public Transform PlayerPosition
    {
        get => _playerPosition;
        set
        {
            _playerPosition = value;
        }
    }

    [Inject]
    private void Construct(Transform playerTransform)
    {
        PlayerPosition = playerTransform;
    }

    private void Update()
    {   
        LogPlayerPos();
    }
    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("I saw player");
        }
    }

    private void LogPlayerPos()
    {
        if (PlayerPosition is not null)
            Debug.Log(PlayerPosition.position);
    }
}
