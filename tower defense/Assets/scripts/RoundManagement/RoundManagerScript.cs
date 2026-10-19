using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RoundManageScript : MonoBehaviour
{
    [SerializeField] private Transform start;


    [Header("Enemies Quantity")]
    [SerializeField] protected int Singular = 1;
    [SerializeField] protected int small = 4;
    [SerializeField] protected int medium = 8;
    [SerializeField] protected int large = 12;
    [SerializeField] protected int big = 20;

    [Header("Spawn Speed")]
    [SerializeField] protected float Xslow = 2;
    [SerializeField] protected float slow = 1;
    [SerializeField] protected float basic = 0.5f;
    [SerializeField] protected float quick = 0.25f;
    [SerializeField] protected float rush = 0.1f;


    [Header("Enemies Level")]
    public GameObject triangleEnemy;
    public GameObject SquareEnemy;
    public GameObject PentagonEnemy;
    public GameObject HexagonEnemy;
    public GameObject CircleBoss;


    public int CurrentRound;
    private bool CurrentRoundEnd = false;

    private bool CoroutineTest = true;
    void Start()
    {
        start = GameObject.Find("RoundManager/Start").transform;


    }
    void Update()
    {
        RoundHandler();
    }


    private void RoundHandler()
    {
        if (CoroutineTest == true)
        {
            StartCoroutine(roundSpawn());
            CoroutineTest = false;

        }

        switch (CurrentRound)
        {
            case 1:
                StartCoroutine(roundSpawn());
                return;
            case 2:
                Debug.Log("");
                return;
            case 3:
                return;
            case 4:
                return;
            case 5:
                return;
            case 6:
                return;
            case 7:
                return;
            case 8:
                return;
            case 9:
                return;
            case 10:
                return;
        }

        RoundEndCheck();
        if (CurrentRoundEnd == true)
        {
            CurrentRound++;
            CurrentRoundEnd = false;
        }
            
    }

    void RoundEndCheck()
    {

    }
    public IEnumerator roundSpawn()
    {
        for (int i = 0; i < 1; i++)
        {
            Instantiate(triangleEnemy, start);
            yield return new WaitForSeconds(0.5f);
        }
        for (int i = 0; i < 12; i++)
        {
            Instantiate(triangleEnemy, start);
            yield return new WaitForSeconds(0.4f);
        }
        for (int i = 0; i < 24; i++)
        {
            Instantiate(triangleEnemy, start);
            yield return new WaitForSeconds(0.2f);
        }
        for (int i = 0; i < 48; i++)
        {
            Instantiate(triangleEnemy, start);
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 48; i++)
        {
            Instantiate(triangleEnemy, start);
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 48; i++)
        {
            Instantiate(triangleEnemy, start);
            yield return new WaitForSeconds(0.1f);
        }

    }
}
