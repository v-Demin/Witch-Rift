using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneLoader : MonoBehaviour
{
    [SerializeField] private UnitView _playerView;
    [SerializeField] private TestFabricator _fabricator;
    
    private void Start()
    {
        //[Todo]: StandardLoading
        FakeLoading();
    }

    private void FakeLoading()
    {
        var unit = new Unit(new List<AbstractUnitComponent>() {_fabricator.Fabricate()});
        
        _playerView.Init(unit);
    }
}
