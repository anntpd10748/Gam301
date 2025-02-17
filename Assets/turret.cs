using UnityEngine;
using UnityEngine.VFX;

public class AoeTurret : MonoBehaviour
{
    public float range = 5f;
    public float damagePerSecond = 20f;
    public VisualEffect visualEffect;
    private bool isActive = false;

    void Update()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, range);
        bool hasEnemies = false;

        foreach (Collider enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                hasEnemies = true;
                enemy.GetComponent<navmeshagent>()?.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
        if (hasEnemies && !isActive)
        {
            visualEffect.Play();
            isActive = true;
        }
        else if (!hasEnemies && isActive)
        {
            visualEffect.Stop();
            isActive = false;
        }
    }
    void Start()
    {
        visualEffect.Stop();
    }

}
