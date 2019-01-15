using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    private void Awake()
    {
        if (instance == null || instance != this)
            instance = this;
    }

    string dataText;
    private Text data;
    private float timePassed;
    private int blockUsed;
    // Start is called before the first frame update
    void Start()
    {
        data = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            timePassed += Time.deltaTime;
            UpdateText();
        }

    }



    private void UpdateText()
    {
        dataText = "Block used: " + blockUsed + "\nTime: " + (int)timePassed + "\nSimilarity:";
        data.text = dataText;
    }

    public void IncreaseBlockUsed()
    {
        blockUsed++;
    }

    public void Reset()
    {
        blockUsed = 0;
        timePassed = 0;
    }

    public void DoneDrawing()
    {
        GameManager.instance.isGameOver = true;
    }
}
