using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    [SerializeField]
    private Text TextScore;

    public int IntScore = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Score();
    }


    private void Score()
    {

        if (Input.GetMouseButtonDown(0))
        {
            IntScore += 1;
        }

        TextScore.text = "Score: " + IntScore;
    }
}
