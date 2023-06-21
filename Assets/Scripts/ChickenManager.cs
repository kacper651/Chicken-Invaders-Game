using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenManager : MonoBehaviour
{
    [SerializeField] GameObject chickenPrefab;
    [SerializeField] float spawnRate = 1f;
    [SerializeField] float spawnRateIncrease = 0.1f;
    [SerializeField] float spawnRateMin = 0.1f;
    [SerializeField] float spawnRateMax = 1f;
    [SerializeField] float spawnXMin = -10f;
    [SerializeField] float spawnXMax = 10f;
    [SerializeField] float spawnYMin = -10f;
    [SerializeField] float spawnYMax = 10f;
    [SerializeField] int maxChickens = 10;
    
    List<Chicken> chickens = new List<Chicken>();

    private void Start()
    {
        StartCoroutine(SpawnChicken());
    }

    IEnumerator SpawnChicken()
    {
        while (true)
        {
            if (chickens.Count < maxChickens)
            {
                float spawnX = Random.Range(spawnXMin, spawnXMax);
                float spawnY = Random.Range(spawnYMin, spawnYMax);
                Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);
                GameObject chicken = Instantiate(chickenPrefab, spawnPos, Quaternion.identity);
                Chicken chickenScript = chicken.GetComponent<Chicken>();
                chickenScript.SetManager(this);
                chickens.Add(chickenScript);
            }
            yield return new WaitForSeconds(spawnRate);
            spawnRate = Mathf.Clamp(spawnRate - spawnRateIncrease, spawnRateMin, spawnRateMax);
        }
    }
}
