using System.Collections;
using abdukulov_talgat.MathGame.Core.Round;

namespace abdukulov_talgat.MathGame.Core;

public class GameSession : IEnumerable<RoundBase>
{
    private readonly Operation _availableOperations;
    private readonly int _roundsCount;

    private readonly List<RoundBase> _roundsList = [];

    public GameSession(int roundsCount, Operation availableOperations)
    {
        _roundsCount = roundsCount;
        _availableOperations = availableOperations;
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < _roundsCount; i++)
        {
            RoundBase roundBase = RoundFactory.Create(_availableOperations);
            _roundsList.Add(roundBase);
        }
    }

    public int GetScore()
    {
        return _roundsList.Sum(r => r.GetScore());
    }

    #region IEnumerable

    // Should I use _roundsList.GetEnumerator() or _roundsList.AsReadOnly().GetEnumerator();
    public IEnumerator<RoundBase> GetEnumerator()
    {
        return _roundsList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}