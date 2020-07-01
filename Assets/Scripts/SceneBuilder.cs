using System.Collections.Generic;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    [SerializeField] Environment environment;
    [SerializeField] Blocks blocks;
    private bool newEnvironment = true;
    private List<Environment> environmentList = new List<Environment> ();
    private float environmentPosition = 0;
    private long score;
    public static float runSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ReEnvironment", 1.0f * 10.0f / runSpeed, 1.0f * 10.0f / runSpeed);

        for (int i = 0; i < 10; i++) //Sahneye yük binmemesi adına, geçilen zemin siliniyor ve ön tarafta yeni bir zemin oluşturuluyor.
        {
            Environment initialEnvironment = Instantiate(environment, new Vector3(environmentPosition, 0.5f, 10.0f), Quaternion.identity);
            environmentList.Add(initialEnvironment);
            environmentPosition += 10.0f;
        }

        Debug.Log(environmentList);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void ReEnvironment()
    {
        Environment newEnvironment = Instantiate(environment, new Vector3(environmentList[environmentList.Count - 1].transform.position.x + 10.0f, 0.5f, 10.0f), Quaternion.identity);
        environmentList.Add(newEnvironment);
        Destroy(environmentList[0].gameObject);
        environmentList.RemoveAt(0);
    }
}