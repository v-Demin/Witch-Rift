using System.Collections.Generic;

namespace Graybox.Core.EventSystem
{
    public class SubscribersList<TSubscriber> where TSubscriber : class
    {
        protected List<TSubscriber> _list = new List<TSubscriber>();

        public List<TSubscriber> List => new List<TSubscriber>(_list);

        public void Add(TSubscriber subscriber)
        {
            _list.Add(subscriber);
        }

        public void Remove(TSubscriber subscriber)
        {
            _list.Remove(subscriber);
        }
    }
}
