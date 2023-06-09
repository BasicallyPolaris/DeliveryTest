using UnityEngine;
using TMPro;

/**
 * This class manages the game logic of scores and tries and displays them.
 */
public class GameLogic : MonoBehaviour {
    
    // The display text for the score and tries
    [SerializeField]
    private TMP_Text displayText;
    private int score;
    private int tries;

    /**
     * Start is called before the first frame update.
     * Used to initialize the score and tries and set the initial View.
     */
    void Start() {
        score = 0;
        tries = 0;
        refreshView();
    }

    /**
     * Used to increase the score and refresh the view.
     */
    public void increseScore() {
        score++;
        refreshView();
    }

    /**
     * Used to increase the tries and refresh the view.
     */
    public void increaseTries() {
        tries++;
        refreshView();
    }

    /**
     * Used to refresh the view.
     */
    private void refreshView() {
        displayText.text = "Score: " + score + "\nTries: " + tries + "\n";
    }
}