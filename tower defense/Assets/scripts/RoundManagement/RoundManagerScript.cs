
using System.Collections;
using UnityEngine;

public class RoundManageScript : MonoBehaviour
{
    [Header("Spawn Point")]
    public Transform start;

    [Header("Enemies Quantity")]
    public int Singular = 1;
    public int small = 4;
    public int medium = 8;
    public int large = 12;
    public int big = 20;

    [Header("Spawn Speed")]
    public float Xslow = 2f;
    public float slow = 1f;
    public float basic = 0.5f;
    public float quick = 0.25f;
    public float rush = 0.1f;

    [Header("Enemy Prefabs")]
    public GameObject triangleEnemy;
    public GameObject FastTriangleEnemy;
    public GameObject SquareEnemy;
    public GameObject HexagonEnemy;
    public GameObject CircleBoss;

    [Header("Round Settings")]
    public int CurrentRound = 1;
    public int MaxRounds = 10;
    public float timeBetweenRounds = 2f;

    private Rounds rounds;

    private void Start()
    {
        rounds = GetComponent<Rounds>();

        StartCoroutine(RunRounds());
    }

    private IEnumerator RunRounds()
    {
        while (CurrentRound <= MaxRounds)
        {

            yield return StartCoroutine(
                rounds.roundSpawn(CurrentRound)
            );


            CurrentRound++;

            if (CurrentRound <= MaxRounds)
                yield return new WaitForSeconds(timeBetweenRounds);
        }
    }
}
