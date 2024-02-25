using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class UnitLoader : MonoBehaviour
{
    [Inject] private readonly DiContainer _container;
    
    public Unit Unit = new ();

    [SerializeField] private UnitView _playerView;
    [SerializeField] private List<UnitComponentSoInstaller> _soFabricators;
    [SerializeField] private List<AbstractUnitComponentMonoInstaller> _monoFabricators;

    
    private void Start()
    {
        Load();
    }

    public Unit Load()
    {
        var components = new List<UnitComponent>();
        components.AddRange(_soFabricators.Select(fabricator => fabricator.Fabricate(_container)).ToList());
        components.AddRange(_monoFabricators.Select(fabricator => fabricator.Fabricate(_container)).ToList());
        
        Unit.AddComponents(components);
        _playerView?.Init(Unit);

        Unit.Name = name;
        
        return Unit;
    }
}
