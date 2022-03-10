using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHitPoints = 5;
    int currentHitPonts = 0;

    private void OnParticleCollision(GameObject other)
    {
        currentHitPonts++;
        Debug.Log(currentHitPonts);
        if (currentHitPonts == maxHitPoints)
        {
            Destroy(gameObject);
        }
    }
}
