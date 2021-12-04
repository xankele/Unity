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
    public Rigidbody2D rb;
    private GameObject _currentLevel;
    bool _isSwitchingState;
    public static GameManager Instance;
    public SpriteRenderer render;

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
    public void ExitClicked()
    {
        Application.Quit();
    }
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        render.enabled = false;
        rb = GetComponent<Rigidbody2D>();
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
                render.enabled = false;
                StartPanel.SetActive(true);
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                break;
            case State.Play:
                render.enabled = true;
                Level = 0;
                SwitchState(State.LoadLevel);
                break;
            case State.LoadLevel:
                if(Level >= Levels.Length)
                {
                    SwitchState(State.End, 2f);
                }
                else
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    _currentLevel = Instantiate(Levels[_level]);
                    Player.transform.position = new Vector2(50.0f, 5.0f);
                }
                break;
            case State.LevelCompleted:
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                LevelCompletedPanel.SetActive(true);
                Destroy(_currentLevel);
                Level++;
                SwitchState(State.LoadLevel, 2f);
                break;
            case State.End:
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                EndPanel.SetActive(true);
                SwitchState(State.Start, 2f);
                break;
        }
    }
    //private void Update()
    //{
    //    switch (_state)
    //    {
    //        case State.Start:
    //            break;
    //        case State.Play:
    //            break;
    //        case State.LoadLevel:
    //            break;
    //        case State.LevelCompleted:
    //            break;
    //        case State.End:
    //            break;
    //    }
    //}
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
            case State.End:
                EndPanel.SetActive(false);
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
    End
}
