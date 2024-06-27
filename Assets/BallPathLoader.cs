using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BallPathLoader : MonoBehaviour
{
    private List<Vector3> ballPositions;

    private void OnEnable()
    {
        LoadLogFromJson();
    }


    void LoadLogFromJson()
    {
        string path = Application.persistentDataPath + "/ball_log.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BallPositionLog log = JsonUtility.FromJson<BallPositionLog>(json);
            ballPositions = log.positions;
        }
        else
        {
            Debug.LogError("Ball log file not found");
        }
    }

    public List<Vector3> GetBallPositions()
    {
        return ballPositions;
    }
}
