using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{

    public GameObject turtlePrefab;
    public GameObject enemyPrefab;
    public int numberOfTurtles = 10;

    public int numberOfEnemies = 2;

    public int minFlockSize = 10;
    public GameObject[] allTurtles;

    public GameObject[] allEnemies;
    public Vector2 terrainLimits = new Vector2(50, 50);

    private float attackDistance = 15f;

    public Vector3 averagePosition;

    public Transform target;
    public Transform safeSpot;

    // Start is called before the first frame update
    void Start()
    {
        allTurtles = new GameObject[numberOfTurtles];
        allEnemies = new GameObject[numberOfEnemies];
        for (int i = 0; i < numberOfTurtles; i++)
        {
            Vector3 position = this.transform.position + new Vector3(
                Random.Range(-terrainLimits.x, terrainLimits.x), 
                0f, Random.Range(-terrainLimits.y, terrainLimits.y));
            allTurtles[i] = Instantiate(turtlePrefab, position, Quaternion.identity);
        }
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 position = this.transform.position + new Vector3(
                Random.Range(-terrainLimits.x, terrainLimits.x), 
                0f, Random.Range(-terrainLimits.y, terrainLimits.y));
            allEnemies[i] = Instantiate(enemyPrefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        calculateAveragePosition();
    }
    public GameObject getNearestNeighbour(GameObject seeker) {
        GameObject nearestNeighbour = allTurtles[0];
        float shortestDistance = Vector3.Distance(nearestNeighbour.transform.position, seeker.transform.position);
        if (shortestDistance == 0f)
        {
            shortestDistance = Mathf.Infinity;
        }
        foreach (GameObject turtle in allTurtles)
        {
            if (!turtle.transform.position.Equals(seeker.transform.position))
            {
                float distance = Vector3.Distance(turtle.transform.position, seeker.transform.position);
                if (distance < shortestDistance)
                {
                    nearestNeighbour = turtle;
                    shortestDistance = distance;
                }
            }
        }
        return nearestNeighbour;
    }
    public bool checkFlock(GameObject seeker, float viewDistance) {
        int numOfNeighbours = 0;
        foreach (GameObject turtle in allTurtles)
        {
            if (Vector3.Distance(turtle.transform.position, seeker.transform.position) < viewDistance)
            {
                numOfNeighbours++;
            }
        }
        return numOfNeighbours >= minFlockSize;
    }

    public bool checkAttack() {
        GameObject nearestEnemy = allEnemies[0];
        float shortestDistance = Vector3.Distance(nearestEnemy.transform.position, allTurtles[0].transform.position);
        foreach (GameObject turtle in allTurtles)
        {
            foreach (GameObject enemy in allEnemies)
            {
                float distance = Vector3.Distance(turtle.transform.position, enemy.transform.position);
                if (distance < shortestDistance)
                {
                    nearestEnemy = enemy;
                    shortestDistance = distance;
                }
            }
        }
        if (shortestDistance <= attackDistance)
        {
            return true;
        }
        return false;
    }

    private void calculateAveragePosition() {
        averagePosition = this.transform.position;
    }
}
