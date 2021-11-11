using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject StartPanel;
    public GameObject LevelCompletedPanel;
    public GameObject EndPanel;
    public GameObject[] Levels;

    private GameObject _currentLevel;
    bool _isSwitchingState;
    public static GameManager Instance;

    State _state;

    private int _level;
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public void PlayClicked()
    {
        SwitchState(State.Play);
    }
    void Start()
    {
        Instance = this;
        SwitchState(State.Start);
    }
    
    public void SwitchState(State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }
    IEnumerator SwitchDelay(State newState, float delay)
    {
        _isSwitchingState = true;
        yield return new WaitForSeconds(delay);
        EndState();
        _state = newState;
        BeginState(newState);
        _isSwitchingState = false;
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.Start:
                StartPanel.SetActive(true);
                break;
            case State.Play:
                Level = 0;
                Player.SetActive(true);
                SwitchState(State.LoadLevel);
                break;
            case State.LoadLevel:
                if(Level >= Levels.Length)
                {
                    SwitchState(State.EndPanel, 5f);
                }
                else
                {
                    _currentLevel = Instantiate(Levels[_level]);
                    Player.SetActive(true);
                    Player.transform.position = new Vector2(-10.0f, -2.0f);
                }
                break;
            case State.LevelCompleted:
                LevelCompletedPanel.SetActive(true);
                Destroy(_currentLevel);
                Level++;
                Player.SetActive(false);
                LevelCompletedPanel.SetActive(true);
                SwitchState(State.LoadLevel, 2f);
                break;
            case State.EndPanel:
                EndPanel.SetActive(true);
                break;
        }
    }
    private void Update()
    {
        switch (_state)
        {
            case State.Start:
                break;
            case State.Play:
                break;
            case State.LoadLevel:
                break;
            case State.LevelCompleted:
                break;
            case State.EndPanel:
                break;
        }
    }
    void EndState()
    {
        switch (_state)
        {
            case State.Start:
                StartPanel.SetActive(false);

                break;
            case State.Play:
                break;
            case State.LoadLevel:
                break;
            case State.LevelCompleted:
                LevelCompletedPanel.SetActive(false);
                break;
            case State.EndPanel:
                StartPanel.SetActive(true);
                break;
        }
    }
}
public enum State
{
    Start,
    Play,
    LevelCompleted,
    LoadLevel,
    EndPanel
}
