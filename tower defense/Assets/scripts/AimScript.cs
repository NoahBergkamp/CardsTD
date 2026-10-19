using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();

    public GameObject bullet;
    public Transform shootPoint;

    [Header("Attack")]
    public float AttackSpeed = 0.1f;
    public int currentDamage = 1;
    public int ProjectileSpeed = 10;

    private GameObject CurrentTarget;

    void Update()
    {
        TargetEnemy();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !targets.Contains(other.gameObject))
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            targets.Remove(other.gameObject);

            if (CurrentTarget == other.gameObject)
            {
                CurrentTarget = null;
            }
        }
    }

    void TargetEnemy()
    {
        targets.RemoveAll(target => target == null);

        if (targets.Count == 0)
        {
            CurrentTarget = null;
            return;
        }

        float currentLowest = Mathf.Infinity;
        GameObject bestTarget = null;

        foreach (GameObject target in targets)
        {
            TrackFollower trackFollow = target.GetComponent<TrackFollower>();

            if (trackFollow == null)
                continue;

            float inTime = trackFollow.ReturnTime();

            if (inTime < currentLowest)
            {
                currentLowest = inTime;
                bestTarget = target;
            }
        }

        if (bestTarget == null)
        {
            CurrentTarget = null;
            return;
        }

        CurrentTarget = bestTarget;

        TrackFollower trackFollower =
            CurrentTarget.GetComponent<TrackFollower>();

        Rigidbody2D targetRb =
            CurrentTarget.GetComponent<Rigidbody2D>();

        Vector2 targetPosition = targetRb.position;

        Vector2 targetVelocity = targetRb.linearVelocity;

        float distance =
            Vector2.Distance(shootPoint.position, targetPosition);

        float timeToTarget = distance / ProjectileSpeed;


        Vector2 futurePosition =
            targetPosition + targetVelocity * timeToTarget;


        Vector2 aimDirection =
            futurePosition - (Vector2)transform.position;

        float angle =
            Mathf.Atan2(aimDirection.y, aimDirection.x)
            * Mathf.Rad2Deg;

        angle -= 90f;

        transform.rotation =
            Quaternion.Euler(0f, 0f, angle);


        AttackSpeed -= Time.deltaTime;

        if (AttackSpeed <= 0)
        {
            AttackSpeed = 0.1f;

            GameObject obj = Instantiate(
                bullet,
                shootPoint.position,
                transform.rotation
            );

            fireBullet bulletScript =
                obj.GetComponent<fireBullet>();

            bulletScript.target = CurrentTarget;
            bulletScript.damage = currentDamage;
            bulletScript.speed = ProjectileSpeed;
        }
    }
}