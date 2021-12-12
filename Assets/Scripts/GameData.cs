using System;

[Serializable]
public class GameData
{
    private float bestScore;

    public float BestScore => bestScore;

    public void Setup(float bestScore)
    {
        this.bestScore = bestScore;
    }
}
