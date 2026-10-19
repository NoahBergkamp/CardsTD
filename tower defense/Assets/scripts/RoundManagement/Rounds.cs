
using System.Collections;
using UnityEngine;

public class Rounds : MonoBehaviour
{
    private RoundManageScript settings;

    private void Awake()
    {
        settings = GetComponent<RoundManageScript>();
    }

    public IEnumerator roundSpawn(int roundNumber)
    {
        switch (roundNumber)
        {
            case 1:
                yield return StartCoroutine(SpawnGroup(
                    settings.triangleEnemy,
                    settings.Singular,
                    settings.Xslow
                ));

                yield return StartCoroutine(SpawnGroup(
                    settings.FastTriangleEnemy,
                    settings.small,
                    settings.slow
                ));
                break;

            case 2:
                yield return StartCoroutine(SpawnGroup(
                    settings.triangleEnemy,
                    settings.small,
                    settings.slow
                ));

                yield return StartCoroutine(SpawnGroup(
                    settings.SquareEnemy,
                    settings.medium,
                    settings.basic
                ));
                break;

            case 3:
                yield return StartCoroutine(SpawnGroup(
                    settings.FastTriangleEnemy,
                    settings.medium,
                    settings.basic
                ));

                yield return StartCoroutine(SpawnGroup(
                    settings.HexagonEnemy,
                    settings.large,
                    settings.quick
                ));
                break;

            case 4:
                yield return StartCoroutine(SpawnGroup(
                    settings.SquareEnemy,
                    settings.large,
                    settings.basic
                ));

                yield return StartCoroutine(SpawnGroup(
                    settings.HexagonEnemy,
                    settings.big,
                    settings.quick
                ));
                break;

            case 5:
                yield return StartCoroutine(SpawnGroup(
                    settings.HexagonEnemy,
                    settings.big,
                    settings.rush
                ));
                break;

            case 6:
                yield return StartCoroutine(SpawnGroup(
                    settings.triangleEnemy,
                    settings.big,
                    settings.quick
                ));

                yield return StartCoroutine(SpawnGroup(
                    settings.SquareEnemy,
                    settings.large,
                    settings.rush
                ));
                break;

            case 7:
                yield return StartCoroutine(SpawnGroup(
                    settings.FastTriangleEnemy,
                    settings.big,
                    settings.rush
                ));

                yield return StartCoroutine(SpawnGroup(
                    settings.HexagonEnemy,
                    settings.big,
                    settings.quick
                ));
                break;

            case 8:
                yield return StartCoroutine(SpawnGroup(
                    settings.SquareEnemy,
                    settings.big,
                    settings.rush
                ));

                yield return StartCoroutine(SpawnGroup(
                    settings.HexagonEnemy,
                    settings.big,
                    settings.rush
                ));
                break;

            case 9:
                yield return StartCoroutine(SpawnGroup(
                    settings.triangleEnemy,
                    settings.big,
                    settings.rush
                ));

                yield return StartCoroutine(SpawnGroup(
                    settings.FastTriangleEnemy,
                    settings.big,
                    settings.rush
                ));

                yield return StartCoroutine(SpawnGroup(
                    settings.HexagonEnemy,
                    settings.big,
                    settings.rush
                ));
                break;

            case 10:
                yield return StartCoroutine(SpawnGroup(
                    settings.CircleBoss,
                    settings.Singular,
                    settings.Xslow
                ));
                break;
        }
    }

    private IEnumerator SpawnGroup(
        GameObject enemyPrefab,
        int amount,
        float delay)
    {
        if (enemyPrefab == null)
        {
            Debug.LogWarning("An enemy prefab is missing!");
            yield break;
        }

        for (int i = 0; i < amount; i++)
        {
            Instantiate(
                enemyPrefab,
                settings.start.position,
                settings.start.rotation
            );

            yield return new WaitForSeconds(delay);
        }
    }
}
