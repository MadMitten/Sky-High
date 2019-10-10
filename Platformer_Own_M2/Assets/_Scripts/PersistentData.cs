using System.Collections.Generic;

public class PersistentData
{
    public List<LevelScore> levelScores; 
    public int completedLevels;
    public int score;
    public string name;

    public PersistentData()
    {
        levelScores = new List<LevelScore>()
        {
            new LevelScore (0,0),
            new LevelScore (0,0),
            new LevelScore (0,0)
        };
        score = 0;
        completedLevels = 1;
        name = " ";
    }
    
}
