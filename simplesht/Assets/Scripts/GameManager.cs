using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int points;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()

    {

    }

    // Update is called once per frame
    public void addPOints(int amount)
    {
        points += amount;
    }

    public void showPoints()
    {
        Debug.Log(points);
    }
}
