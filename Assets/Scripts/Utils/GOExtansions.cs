﻿using UnityEngine;

namespace Utils
{
    public static class GOExtansions
    {
        public static bool IsInLayer(this GameObject go, LayerMask layer)
        {
            return layer == (layer | 1 << go.layer);
        }
        
        public static TInterfaceType GetInterface<TInterfaceType>(this Collider2D go)
        {
            var components = go.GetComponents<Component>();
            foreach (var component in components)
            {
                if (component is TInterfaceType type)
                {
                    return type;
                }
            }

            return default;
        }
    }
}