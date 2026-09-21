using System.Collections;
using abdukulov_talgat.MathGame.Core.Round;

namespace abdukulov_talgat.MathGame.Core;

public class GameSession : IEnumerable<RoundBase>
{
    private readonly Operation _availableOperations;

    private readonly List<RoundBase> _roundsList = [];

    public GameSession(Operation availableOperations)
    {
        _availableOperations = availableOperations;
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < AppConsts.RoundsPerSession; i++)
        {
            RoundBase roundBase = RoundFactory.Create(_availableOperations);
            _roundsList.Add(roundBase);
        }
    }

    public float TotalScore => _roundsList.Sum(r => r.GetScore());

    public double SecondsSpent { get; private set; }

    private void MeasureTimeSpent(int i, DateTime start)
    {
        _roundsList[i].OnRoundFinished += () =>
        {
            DateTime end = DateTime.Now;
            SecondsSpent = (end - start).TotalSeconds;
        };
    }

    private static bool IsItLastRound(int i)
    {
        return i == AppConsts.RoundsPerSession - 1;
    }

    #region IEnumerable

    public IEnumerator<RoundBase> GetEnumerator()
    {
        DateTime start = DateTime.Now;
        for (int i = 0; i < AppConsts.RoundsPerSession; i++)
        {
            if (IsItLastRound(i))
            {
                MeasureTimeSpent(i, start);
            }

            yield return _roundsList[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}