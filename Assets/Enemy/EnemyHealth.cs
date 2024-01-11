using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHitPoints = 5;

    [Tooltip("Adds amount to maxHitPoints hen enemy dies")]
    [SerializeField] private int _difficultRamp = 1;

    private int _currentHitPoint = 0;
    private Enemy _enemy;

    private void OnEnable()
    {
        _currentHitPoint = _maxHitPoints;
    }

    private void Start()
    {
        _enemy = GetComponent<Enemy>();    
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        _currentHitPoint--;

        if (_currentHitPoint <= 0)
        {
            _enemy.RewardGold();
            _maxHitPoints += _difficultRamp;
            gameObject.SetActive(false);
        }
    }
}