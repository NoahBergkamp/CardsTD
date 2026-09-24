using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();

    public GameObject bullet;
    public Transform shootPoint;

    private float AttackSpeed;
    private GameObject CurrentTarget;

    void Start()
    {
        AttackSpeed = 0.1f;
    }

    void Update()
    {
        targetEnemy();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!targets.Contains(other.gameObject))
            {
                targets.Add(other.gameObject);
            }
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

    void targetEnemy()
    {
        targets.RemoveAll(target => target == null);

        // No targets
        if (targets.Count == 0)
        {
            CurrentTarget = null;
            return;
        }
        float currentLowest = Mathf.Infinity;
        GameObject bestTarget = null;

        foreach (GameObject target in targets)
        {
            TrackFollower trackFollower = target.GetComponent<TrackFollower>();

            if (trackFollower == null)
                continue;

            float inTime = trackFollower.ReturnTime();

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

        // Set current target
        CurrentTarget = bestTarget;

        // Aim at target
        Vector3 aimDir = (CurrentTarget.transform.position - transform.position).normalized;

        Quaternion rot = Quaternion.LookRotation(Vector3.forward, aimDir);
        transform.rotation = rot;

        // Shooting timer
        AttackSpeed -= Time.deltaTime;

        if (AttackSpeed <= 0)
        {
            AttackSpeed = 0.1f;

            Instantiate(
                bullet,
                shootPoint.position,
                transform.rotation
            );
        }
    }
}