using UnityEngine;
using Zenject;

public class CameraUnitInstaller : MonoInstaller
{
    [SerializeField] private UnitLoader CameraUnitLoader;
    
    public override void InstallBindings()
    {
        Container.Bind<EventHolder>()
            .WithId("Camera")
            .FromInstance(CameraUnitLoader.Unit.LocalEventHolder);
    }
}