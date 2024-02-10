using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleSceneLoader : MonoBehaviour
{
    [SerializeField] private UnitView _playerView;
    [FormerlySerializedAs("_fabricator")] [SerializeField] private TestSoFabricator soFabricator;
    
    private void Start()
    {
        //[Todo]: StandardLoading
        FakeLoading();
    }

    private void FakeLoading()
    {
        var unit = new Unit(new List<UnitComponent>() {soFabricator.Fabricate()});
        
        _playerView.Init(unit);
    }
}
