using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeadboardSaver{

    string dataPath;

    public LeadboardSaver ()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "LeaderboardData.txt");
	}

    public void saveBoard(Leaderboard data)
    {
        string jsonString = JsonUtility.ToJson(data);
        using (StreamWriter streamWriter = File.CreateText(dataPath))
        {
            streamWriter.Write(jsonString);
        }
    }

    public Leaderboard loadBoard()
    {
        Leaderboard lb = null;
        try
        {
            using (StreamReader streamReader = File.OpenText(dataPath))
            {
                string jsonString = streamReader.ReadToEnd();
                lb = JsonUtility.FromJson<Leaderboard>(jsonString);
            }
        } catch
        {

        }
        return lb;
    }
}
