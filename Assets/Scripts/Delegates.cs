using System;
using UnityEngine;

namespace Test
{
    public static class Delegates
    {
        public delegate void ShowEventHandler(string json);
        public static ShowEventHandler DelegateEventHandler = new ShowEventHandler(EventHandler.ViewJson);
    }
}
