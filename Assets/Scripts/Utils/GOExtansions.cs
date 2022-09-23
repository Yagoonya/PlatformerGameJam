﻿using UnityEngine;

namespace Scripts.Utils
{
    public static class GOExtansions
    {
        public static bool IsInLayer(this GameObject go, LayerMask layer)
        {
            return layer == (layer | 1 << go.layer);
        }
    }
}