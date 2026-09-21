using abdukulov_talgat.MathGame.Core.Round;

namespace abdukulov_talgat.MathGame.Core;

public class Game
{
    private readonly IList<GameSession> _sessionList = [];

    public IEnumerable<RoundBase> GetSessionRounds(Operation operation)
    {
        GameSession session = new(operation);
        _sessionList.Add(session);
        return session;
    }

    public int GetLastSessionScore()
    {
        return _sessionList.Last().GetScore();
    }

    public IReadOnlyList<GameSession> GetSessionsHistory() => _sessionList.AsReadOnly();
}