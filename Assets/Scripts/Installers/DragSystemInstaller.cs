using UnityEngine;
using Zenject;

public class DragSystemInstaller : MonoInstaller
{
    [SerializeField] private DragSystem dragSystem;
    public override void InstallBindings()
    {
        // ����������� ������ dragSystem � ������ DragSystem
        Container.Bind<DragSystem>().FromInstance(dragSystem).AsSingle();
    }
}