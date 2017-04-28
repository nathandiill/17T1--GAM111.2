using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Handles inputs and buttons etc. for the GameOver Screen/state
*/
public class GameOverController : MonoBehaviour {

    public void OnReturnToGenHit()
    {
        GetComponent<GameStateManager>().GoToGenerate();
    }
}
