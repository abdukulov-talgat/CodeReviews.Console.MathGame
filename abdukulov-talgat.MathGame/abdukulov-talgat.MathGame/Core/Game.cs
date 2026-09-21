using abdukulov_talgat.MathGame.Core.Round;

namespace abdukulov_talgat.MathGame.Core;

public class Game
{
    public static Game Instance
    {
        get
        {
            if (field == null) field = new Game();
            return field;
        }
    }
    
    private Game(){}

    private readonly IList<GameSession> _sessionList = [];

    public Difficulty Difficulty { get; private set; }

    public IEnumerable<RoundBase> GetSessionRounds(Operation operation)
    {
        GameSession session = new(operation);
        _sessionList.Add(session);
        return session;
    }

    public float GetLastSessionScore()
    {
        return _sessionList.Last().GetScore();
    }

    public IReadOnlyList<GameSession> GetSessionsHistory() => _sessionList.AsReadOnly();

    public void ChangeDifficulty(Difficulty difficulty)
    {
        Difficulty = difficulty;
    }
}