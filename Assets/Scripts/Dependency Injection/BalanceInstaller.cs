using UnityEngine;
using Zenject;

public class BalanceInstaller : MonoInstaller
{
    [SerializeField] private Balance _balance;

    public override void InstallBindings()
    {
        Container.Bind<Balance>().FromInstance(_balance).AsSingle().NonLazy();
    }
}