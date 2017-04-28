using MonsterLove.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
    Central point for the major states of the turn based battler.
*/
public class GameStateManager : MonoBehaviour {

    public enum State
    {
        Generate,
        Turns,
        GameOver
    }

    StateMachine<State> fsm;
    
    public GameObject generatePanel, gameRootPanel, gameOverPanel;

	public BaseAI theAi;

    public float fadeTime = 0.5f;

    // Use this for initialization
    void Start ()
    {
        fsm = StateMachine<State>.Initialize(this);

        gameRootPanel.SetActive(false);
        generatePanel.SetActive(false);
        gameOverPanel.SetActive(false);
		theAi.enabled = false;

        fsm.ChangeState(State.Generate);
    }

    public void Generate_Enter()
    {
        generatePanel.SetActive(true);
    }

    public IEnumerator Generate_Exit()
    {
        LeanTween.alphaCanvas(generatePanel.GetComponent<CanvasGroup>(),0, fadeTime)
            .setEase(LeanTweenType.easeInQuad);
        
        yield return new WaitForSeconds(fadeTime);
        generatePanel.SetActive(false);
    }

    public void Turns_Enter()
    {
        gameRootPanel.SetActive(true);
        GetComponent<TurnManager>().BeginGame();
		theAi.enabled = true;
    }

    public void Turns_Exit()
    {
		theAi.enabled = false;
        gameRootPanel.SetActive(false);
    }

    public void GameOver_Enter()
    {
        gameOverPanel.SetActive(true);
    }

    public void GameOver_Exit()
    {
        gameOverPanel.SetActive(false);
    }

    public void BeginGame()
    {
        fsm.ChangeState(State.Turns);
    }

    public void EndOfGame()
    {
        fsm.ChangeState(State.GameOver);
    }

    public void GoToGenerate()
    {
        fsm.ChangeState(State.Generate);
    }
}
