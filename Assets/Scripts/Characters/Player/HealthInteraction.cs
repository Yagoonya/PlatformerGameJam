using Characters.Enemies.Boss;
using UnityEngine;

namespace Characters.Player
{
    public class HealthInteraction : MonoBehaviour
    {
        [SerializeField] private int _changingValue;

        public void ApplyChange(GameObject target)
        {
            var healthComponent = target.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.ApplyChange(_changingValue);
            }
        }
    }
}