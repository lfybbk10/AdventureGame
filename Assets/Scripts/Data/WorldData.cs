
[System.Serializable]
public class WorldData
{
    public string LevelName;
    public PositionOnLevel HeroPositionOnLevel;

    public WorldData(string levelName)
    {
        LevelName = levelName;
        HeroPositionOnLevel = new PositionOnLevel(levelName);
    }
}