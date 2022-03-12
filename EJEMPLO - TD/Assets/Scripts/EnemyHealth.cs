using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHitPoints = 5;
    
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyEnemy = 1;
    
    [SerializeField] int currentHitPonts = 0;

    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        currentHitPonts = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHitPonts--;
        if (currentHitPonts <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            maxHitPoints += difficultyEnemy;
            enemy.RewardGold();
        }
    }
}
