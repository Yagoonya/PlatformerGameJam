using System;
using UnityEngine;

public class CameraAI : MonoBehaviour
{
    private Vector3 _default;

    private void Awake()
    {
        _default = transform.localPosition;
    }

    [ContextMenu("Down")]
    public void LookDown()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, -3f);
    }

    [ContextMenu("Up")]
    public void LookUp()
    {
        transform.localPosition = _default;
    }
}