using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FakeLoader : MonoBehaviour
{
    [SerializeField] private UnitView _playerView;
    [SerializeField] private List<AbstractUnitComponentFabricator> _fabricators;
    
    private void Start()
    {
        LoadAsFake();
    }

    private void LoadAsFake()
    {
        var unit = new Unit(_fabricators.Select(fabricator => fabricator.Fabricate()).ToList());
        _playerView.Init(unit);
    }
}
