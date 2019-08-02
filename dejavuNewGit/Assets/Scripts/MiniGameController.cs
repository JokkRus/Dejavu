using UnityEngine;
using System.Collections;

public abstract class MiniGameController : MonoBehaviour
{
    
    [Range(1,3)]
    public int Difficulty = 1;
    protected void Awake()
    {
        isPlaying = true;
        if (StandartGameController.difficulty != 0)
            Difficulty = StandartGameController.difficulty;
    }
    protected bool isPlaying;
    public IEnumerator WaitForEndOfGame()
    {
        while (isPlaying) yield return null;
    }
    public void EndGame(bool win)
    {
        Debug.Log(win);
        isPlaying = false;
        StandartGameController.win = win;
    }

}
