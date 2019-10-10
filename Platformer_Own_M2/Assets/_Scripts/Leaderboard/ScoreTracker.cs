using UnityEngine;

public class ScoreTracker{

    int score;
    float time;

    public ScoreTracker()
    {
        resetScore();
    }

    public void calculateScore(LevelScore ls)
    {
        score += (int)ls.timeRemaining * ls.coinsCollected;
        time += (2 * 60f) - ls.timeRemaining;
        Debug.Log("Time: " + time);
    }
    
    public void resetScore()
    {
        score = 0;
        time = 0;
    }

    public int getScore()
    {
        return score;
    }

    public float getTime()
    {
        Debug.Log("time: " + time);
        return time;
    }
}
