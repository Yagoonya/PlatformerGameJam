using UnityEngine;
using Utils;

public class TentacleAI : MonoBehaviour
{
    [SerializeField] private CheckCircleOverlap _attackRange;

    public void AttackCheck()
    {
        _attackRange.Check();
    }

}
