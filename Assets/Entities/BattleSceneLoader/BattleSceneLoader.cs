using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleSceneLoader : MonoBehaviour
{
    [SerializeField] private UnitView _playerView;
    [FormerlySerializedAs("soFabricator")] [FormerlySerializedAs("_fabricator")] [SerializeField] private TestSoInstaller soInstaller;
    
    private void Start()
    {
        //[Todo]: StandardLoading
        FakeLoading();
    }

    private void FakeLoading()
    {
        var unit = new Unit(new List<UnitComponent>() {soInstaller.Fabricate()});
        
        _playerView.Init(unit);
    }
}
