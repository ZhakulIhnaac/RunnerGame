using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float playerSpeed = SceneBuilder.runSpeed;
    private int position;
    public int scorePoint;
    [SerializeField] Text score;
    // Start is called before the first frame update
    void Start()
    {
        position = 0;
        scorePoint = 0;
    }

// Update is called once per frame
void Update()
    {
        score.text = "Score: " + scorePoint;
        scorePoint += 10; 
        var nextVector = new Vector3(transform.position.x + Time.deltaTime * playerSpeed, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && position < 6)
        {
            nextVector += new Vector3(0, 0, 1);
            position++;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && position > -6)
        {
            nextVector += new Vector3(0, 0, -1);
            position--;
        }

        transform.position = nextVector;
    }
}
