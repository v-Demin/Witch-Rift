using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrushAI : AbstractUnitComponent
{
    private Transform _target;
    
    private void Start()
    {
        _target = GameObject.Find("CrushFactory").transform;
    }

    private void Update()
    {
        var tempUnits = new List<AbstractBody>();
        OwnerBus.RaiseEvent<IUnitVisionRequestHandler>(handler => tempUnits = handler.HandleRequestAllUnitBodies(0.5f, _ => true));

        if (tempUnits.Count <= 1)
        {
            BasicMove();
        }
        else
        {
            RunAway(tempUnits);
        }
    }

    private void BasicMove()
    {
        var movingDelta = (_target.transform.position - transform.position).normalized;
            
        OwnerBus.RaiseEvent<IMovingRequestHandler>(handler => handler.HandleMovingRequest(movingDelta));
    }

    private void RunAway(IEnumerable<AbstractBody> tempUnits)
    {
        var closest = tempUnits.Aggregate((cur, next) =>
            Vector3.Magnitude(transform.position - cur.transform.position) >
            Vector3.Magnitude(transform.position - next.transform.position)
                ? cur : next);

        var movingDelta = (transform.position - closest.transform.position).normalized;
        
        OwnerBus.RaiseEvent<IMovingRequestHandler>(handler => handler.HandleMovingRequest(movingDelta));
    }
}
