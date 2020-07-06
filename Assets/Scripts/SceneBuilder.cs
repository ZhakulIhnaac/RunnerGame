using System.Collections.Generic;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    [SerializeField] Environment environment;
    [SerializeField] Blocks blocks;
    private bool newEnvironment = true;
    private List<Environment> environmentList = new List<Environment> ();
    private List<GameObject> blockList = new List<GameObject> ();
    private float environmentPosition = 0;
    private long score;
    public static float runSpeed = 20.0f;
    private Vector3 spawnPosition;
    [SerializeField] private GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ReEnvironment", 1.0f * 10.0f / runSpeed, 1.0f * 10.0f / runSpeed);

        for (int i = 0; i < 10; i++) //Sahneye yük binmemesi adına, geçilen zemin siliniyor ve ön tarafta yeni bir zemin oluşturuluyor.
        {
            GameObject initialBlock = new GameObject();
            Environment initialEnvironment = Instantiate(environment, new Vector3(environmentPosition, 0.5f, 10.0f), Quaternion.identity);
            environmentList.Add(initialEnvironment);
            blockList.Add(initialBlock);
            environmentPosition += 10.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void ReEnvironment()
    {
        var randInt = Mathf.Round(Random.Range(-6,6));
        Environment newEnvironment = Instantiate(environment, new Vector3(environmentList[environmentList.Count - 1].transform.position.x + 10.0f, 0.5f, 10.0f), Quaternion.identity);
        GameObject newBlock = Instantiate(block, new Vector3(environmentList[environmentList.Count - 1].transform.position.x + 10.0f, 1.3f, 10.0f + randInt), Quaternion.identity);
        environmentList.Add(newEnvironment);
        blockList.Add(newBlock);
        Destroy(environmentList[0].gameObject);
        Destroy(blockList[0].gameObject);
        environmentList.RemoveAt(0);
        blockList.RemoveAt(0);
    }
}