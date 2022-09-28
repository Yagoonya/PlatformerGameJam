using UnityEngine;
using Utils;

namespace Characters.Enemies
{
    public class DisableChecker: DisableObject
    {
        [SerializeField] private GameObject _gameObject;

        public override void SetActivate(bool value)
        {
            _gameObject.SetActive(value);
        }
    }
}