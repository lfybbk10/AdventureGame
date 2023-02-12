
[System.Serializable]
public class PositionOnLevel
{
    public Vector3Data Position;
    public string LevelName;
    
    public PositionOnLevel(string level, Vector3Data position)
    {
        LevelName = level;
        Position = position;
    }

    public PositionOnLevel(string level)
    {
        LevelName = level;
        
    }
}