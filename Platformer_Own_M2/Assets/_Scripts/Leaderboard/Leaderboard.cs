using System;

[Serializable]

public class Leaderboard
{
    public string[] names;
    public int[] scores;

    public string[] namesTime;
    public float[] times;
    
    public Leaderboard ()
    {
        names = new string[5];
        scores = new int[5];

        namesTime = new string[5];
        times = new float[5];

        emptyBoard();
    }

    void emptyBoard()
    {
        for(int i = 0; i < 5; i++)
        {
            names[i] = "---";
            scores[i] = 0;


            namesTime[i] = "---";
            times[i] = (2*60f)*3;
        }
    }

    int highestScore()
    {
        return scores[0];
    }

    int lowestScore()
    {
        return scores[4];
    }

    float slowestTime()
    {
        return times[4];
    }

    public void addScore(string nam, int newScore)
    {
        for(int i = 0;i<5;i++)
        {
            if(newScore>scores[i])
            {
                moveDown(i);
                scores[i] = newScore;
                names[i] = nam;
                i = 5;//to break the loop instantly.
            }
        }
    }

    public void addTime(string nam, float newTime)
    {
        for (int i = 0; i < 5; i++)
        {
            if(newTime<times[i])
            {
                moveDownTime(i);
                times[i] = newTime;
                namesTime[i] = nam;
                i = 5;
            }
        }
    }

    public bool isFastestTime(float t)
    {
        bool placed = false;

        if(t <= slowestTime())
        {
            placed = true;
        }
        return placed;
    }

    public bool isHighScore(int score)
    {
        bool placed = false;
        if(score >= lowestScore())
        {
            placed = true;
        }
        return placed;
    }

    void moveDown(int index)
    {
        for(int i = scores.Length-1; i>index ;i--)
        {
            if(i!=index)
            {
                scores[i] = scores[i - 1];
                names[i] = names[i - 1];
            }
        }
    }

    void moveDownTime(int index)
    {
        for (int i = times.Length - 1; i > index; i--)
        {
            if (i != index)
            {
                times[i] = times[i - 1];
                namesTime[i] = namesTime[i - 1];
            }
        }
    }
}
