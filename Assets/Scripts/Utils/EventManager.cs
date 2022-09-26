using System;
using UnityEngine;

namespace Utils
{
    public class EventManager : MonoBehaviour
    {
        public static event Action WorldChanged;

        public static void OnWorldChanged()
        {
            WorldChanged?.Invoke();
        }

    }
}