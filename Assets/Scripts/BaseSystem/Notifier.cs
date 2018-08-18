using System.Collections.Generic;

public delegate void EventHandler(object param);

public class Notifier<T>: Singleton<T> where T: class, new()
{
    Dictionary<string, EventHandler> eventDict;

    public Notifier()
    {
        eventDict = new Dictionary<string, EventHandler>();
    }

    public void AddEventHandler(string type, EventHandler e)
    {
        if(!eventDict.ContainsKey(type))
        {
            eventDict.Add(type, e);
        }
        else
        {
            eventDict[type] += e;
        }
    }

    public void RemoveEventHandler(string type, EventHandler e)
    {
        if (eventDict.ContainsKey(type))
        {
            eventDict[type] -= e;
            if(eventDict[type].GetInvocationList().Length == 0)
            {
                eventDict.Remove(type);
            }
        }
    }

    public void RemoveAllEventHandler(string type)
    {
        eventDict.Remove(type);
    }

    public void RaiseEvent(string type, object param = null)
    {
        if(eventDict.ContainsKey(type))
        {
            eventDict[type](param);
        }
    }
}
