using UnityEngine;

public class GameLogic : MonoBehaviour {
    
    private int score;

    void Start() {
        score = 0;
    }

    public void increseScore() {
        score++;
        refreshView();
    }

    private void refreshView() {

    }
}