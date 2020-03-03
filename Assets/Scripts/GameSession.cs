public class GameSession
{

    static int score;

    static public void AddScore(int points)
    {
        score += points;
    }

    static public int GetScore()
    {
        return score;
    }

    static public void Reset()
    {
        score = 0;
    }
}
