using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocate : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem particleProjectile;
    [SerializeField] float range;
    Transform target;


    // Update is called once per frame
    void Update()
    {
        ClosetEnemy();
        Aim();
    }
    void ClosetEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closetEnemy = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closetEnemy = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closetEnemy;
    }
    void Aim()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if (targetDistance < range)
        {
            Attack(true);
        }
        else
            Attack(false);
    }

    void Attack(bool _isAttack)
    {
        var emission = particleProjectile.emission;
        emission.enabled = _isAttack;
    }
}
