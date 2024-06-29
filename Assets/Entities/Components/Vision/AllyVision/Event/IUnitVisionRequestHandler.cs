using System;
using System.Collections.Generic;

public interface IUnitVisionRequestHandler : ISubscriber
{
    List<AbstractBody> HandleRequestAllUnitBodies(float radius, Func<AbstractBody, bool> filter);
    AbstractBody HandleRequestUnitBody(float radius, Func<AbstractBody, bool> filter);
}
