using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float levelFinishTime = 5f;

    [SerializeField]
    private Text timeText;

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private GameObject failPanel;

    [SerializeField]
    private List<GameObject> destroyAfterGame;

    public bool gameFinished = false;
    public bool gameOver = false;

    private void Awake()
    {
        destroyAfterGame = new List<GameObject>();
    }
    private void Start()
    {

    }

    void Update()
    {
        UpdateTheTimer();
        if (Time.timeSinceLevelLoad >= levelFinishTime && !gameOver)
        {
            gameFinished = true;
            winPanel.SetActive(true);
            failPanel.SetActive(false);
            UpdateObjectList("Objects");
            UpdateObjectList("Enemy");
            UpdateObjectList("Player");


            foreach (var allObjects in destroyAfterGame)
            {
                Destroy(allObjects);
            }
        }
        if (gameOver)
        {
            failPanel.SetActive(true);
            winPanel.SetActive(false);
            UpdateObjectList("Objects");
            UpdateObjectList("Enemy");
            UpdateObjectList("Player");
            foreach (var allObjects in destroyAfterGame)
            {
                Destroy(allObjects);
            }
        }
    }

    private void UpdateTheTimer()
    {
        if (!gameOver && !gameFinished)
        {
            timeText.text = "Time: " + (int)Time.timeSinceLevelLoad;
        }
    }

    private void UpdateObjectList(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
    }
}
