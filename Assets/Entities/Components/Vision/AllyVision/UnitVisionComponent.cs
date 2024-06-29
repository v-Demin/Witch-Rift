using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitVisionComponent : AbstractUnitComponent, IUnitVisionRequestHandler
{
    
    public List<AbstractBody> HandleRequestAllUnitBodies(float radius, Func<AbstractBody, bool> filter)
    {
        return FindUnitsInRadius(radius).Where(filter).ToList();
    }

    public AbstractBody HandleRequestUnitBody(float radius, Func<AbstractBody, bool> filter)
    {
        return FindUnitsInRadius(radius).FirstOrDefault(filter);
    }
    
    private float _debugRadius;
    
    private IEnumerable<AbstractBody> FindUnitsInRadius(float radius)
    {
        _debugRadius = radius;
        var hits = Physics2D.CircleCastAll(transform.position, radius, Vector3.forward, radius);
        
        var enumerable = hits.ToList()
            .Select(hit => hit.transform.gameObject.TryGetComponent<AbstractBody>(out var unit) ? unit : null)
            .Where(body => body != null);
        
        return enumerable;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _debugRadius);
    }
}
