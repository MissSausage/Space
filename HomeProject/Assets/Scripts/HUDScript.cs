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

    public GameObject _gameOverPanel;
    GameObject respawn;

    public GameObject _mainMenuPanel;
    public bool mainIsActive;

    private void Start()
    {
        health = GameObject.Find("HUD").transform.GetChild(0).GetComponent<Text>();
        score = GameObject.Find("HUD").transform.GetChild(1).GetComponent<Text>();

        spaceShip = GameObject.Find("spaceship");

        _gameOverPanel = GameObject.Find("HUD").transform.GetChild(2).gameObject;
        _gameOverPanel.SetActive(false);
        respawn = GameObject.Find("Respawn");

        _mainMenuPanel = GameObject.Find("HUD").transform.GetChild(3).gameObject;
        _mainMenuPanel.SetActive(true);
        mainIsActive = true;
    }

    private void FixedUpdate()
    {
        HealthGUI();
        ScoreGUI();
        GameOver();
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

    void GameOver()
    {
        if(GameObject.Find("spaceship").GetComponent<spaceShipScript>().gameOverActive == true)
        {
            _gameOverPanel.transform.GetChild(2).GetComponent<Text>().text = ("SCORE: " + counter);
        }
    }
    
    public void TryAgain()
    {
        spaceShip.transform.position = respawn.transform.position;
        Destroy(GameObject.Find("EnemyParent"));
        GameObject goParent = Instantiate(Resources.Load<GameObject>("EnemyParent"), transform.position, Quaternion.identity);
        goParent.name = ("EnemyParent");
        GameObject.Find("spaceship").GetComponent<spaceShipScript>().shipHealth = 100;
        counter = 0;
        _gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        if(mainIsActive)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Play()
    {
        spaceShip.transform.position = respawn.transform.position;
        Destroy(GameObject.Find("EnemyParent"));
        GameObject goParent = Instantiate(Resources.Load<GameObject>("EnemyParent"), transform.position, Quaternion.identity);
        goParent.name = ("EnemyParent");
        GameObject.Find("spaceship").GetComponent<spaceShipScript>().shipHealth = 100;
        counter = 0;
        Time.timeScale = 1;
        _mainMenuPanel.SetActive(false);
        mainIsActive = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GameOverExit()
    {
        _mainMenuPanel.SetActive(true);
        _gameOverPanel.SetActive(false);
        mainIsActive = true;
    }
}
