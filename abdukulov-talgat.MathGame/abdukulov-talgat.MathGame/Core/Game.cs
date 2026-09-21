using abdukulov_talgat.MathGame.Core.Round;

namespace abdukulov_talgat.MathGame.Core;

public class Game(int rounds)
{
    private readonly int _rounds = rounds;

    private readonly IList<GameSession> _sessionList = [];

    public IEnumerable<RoundBase> GetSessionRounds(Operation operation)
    {
        GameSession session = new(_rounds, operation);
        _sessionList.Add(session);
        return session;
    }

    public int GetLastSessionScore()
    {
        return _sessionList.Last().GetScore();
    }

    public IReadOnlyList<GameSession> GetSessionsHistory() => _sessionList.AsReadOnly();
}