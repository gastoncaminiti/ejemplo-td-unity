using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHitPoints = 5;
    int currentHitPonts = 0;

    private void OnEnable() {
        currentHitPonts = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHitPonts--;
        if (currentHitPonts <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
