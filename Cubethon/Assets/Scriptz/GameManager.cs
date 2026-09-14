using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public bool record = false;
    public bool replay = false;

    private void OnEnable()
    {
        EventBus.Subscribe(EventType.REPLAY, Replay);
        EventBus.Subscribe(EventType.RECORD, Record);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(EventType.RECORD, Record);
        EventBus.Unsubscribe(EventType.REPLAY, Replay);
    }
    
    public void CompleteLevel()
    {
       completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");
            Invoke("Restart", restartDelay); //delay executing Restart() for however long (seconds) restartDelay is set to 
        }
        
    }

    public void Record()
    {
        gameHasEnded = false;
        record = true;
        replay = false;
    }

    public void Replay()
    {
        gameHasEnded = false;
        record = false;
        replay = true;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //loads the name of whatever scene is active
    }
}
