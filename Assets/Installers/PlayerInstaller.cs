using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _spawnPos;

    public override void InstallBindings()
    {
        var playerInstance =
            Container.InstantiatePrefabForComponent<Player>
                (_player, _spawnPos.position, quaternion.identity, null);

        Container.Bind<Player>().FromInstance(playerInstance).AsSingle();
        Container.Bind<Transform>().FromInstance(_playerTransform).AsSingle();
    }
}