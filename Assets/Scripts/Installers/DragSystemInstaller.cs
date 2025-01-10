using UnityEngine;
using Zenject;

public class DragSystemInstaller : MonoInstaller
{
    [SerializeField] private DragSystem dragSystem;
    public override void InstallBindings()
    {
        // Привязываем обьект dragSystem к классу DragSystem
        Container.Bind<DragSystem>().FromInstance(dragSystem).AsSingle();
    }
}