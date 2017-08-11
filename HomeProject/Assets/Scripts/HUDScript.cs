using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    Text health;
    public Text score;
    GameObject spaceShip;
    public int counter;

    private void Start()
    {
        health = GameObject.Find("HUD").transform.GetChild(0).GetComponent<Text>();
        score = GameObject.Find("HUD").transform.GetChild(1).GetComponent<Text>();

        spaceShip = GameObject.Find("spaceship");
    }

    private void Update()
    {
        HealthGUI();
        ScoreGUI();
    }

    void HealthGUI()
    {
        health.text = ("Health: " + spaceShip.GetComponent<spaceShipScript>().shipHealth);
        //Debug.Log(spaceShip.GetComponent<spaceShipScript>().shipHealth);
    }

    void ScoreGUI()
    {
        score.text = ("Score: " + counter);
    }
}
