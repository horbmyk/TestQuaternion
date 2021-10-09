using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public static class EventHandler
    {
       // public static event ShowEventHandler ViewEvent =
        public static void ViewJson(string json)
        {
            Debug.Log("ViewJson");
            Debug.Log(json);
        }
    }
}
