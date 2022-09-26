using System;
using UnityEngine;

namespace Characters.Enemies
{
    public class EyeBehaviour : MonoBehaviour
    {
        private Patrol _patrol;

        private void Awake()
        {
            _patrol = GetComponent<Patrol>();
        }

        private void Start()
        {
            StartCoroutine(_patrol.DoPatrol());
        }
    }
}