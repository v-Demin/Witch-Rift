using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FakeLoader : MonoBehaviour
{
    [SerializeField] private UnitView _playerView;
    [SerializeField] private List<AbstractUnitComponentSoFabricator> _soFabricators;
    [SerializeField] private List<AbstractUnitComponentMonoFabricator> _monoFabricators;
    
    private void Start()
    {
        LoadAsFake();
    }

    private void LoadAsFake()
    {
        var components = _soFabricators.Select(fabricator => fabricator.Fabricate()).ToList();
        components.AddRange(_monoFabricators.Select(fabricator => fabricator.Fabricate()).ToList());
        
        var unit = new Unit(components);
        _playerView.Init(unit);
    }
}
