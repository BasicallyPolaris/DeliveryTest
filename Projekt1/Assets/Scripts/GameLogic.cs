using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour {
    
    [SerializeField]
    private TMP_Text displayText;
    private int score;
    private int tries;

    void Start() {
        score = 0;
        tries = 0;
        refreshView();
    }

    public void increseScore() {
        score++;
        refreshView();
    }

    public void increaseTries() {
        tries++;
        refreshView();
    }

    private void refreshView() {
        displayText.text = "Score: " + score + "\nTries: " + tries + "\n";
    }
}