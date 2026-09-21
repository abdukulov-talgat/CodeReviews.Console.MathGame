using System.ComponentModel;
using abdukulov_talgat.MathGame.Core.Round;

namespace abdukulov_talgat.MathGame.Core;

[Flags]
public enum Operation
{
    [Description("+")] [RoundCreator(typeof(PlusRound))]
    Plus = 1,

    [Description("-")] [RoundCreator(typeof(MinusRound))]
    Minus = 2,

    [Description("*")] [RoundCreator(typeof(MultiplyRound))]
    Multiply = 4,

    [Description("/")] [RoundCreator(typeof(DivisionRound))]
    Division = 8,


    [Description("Random")] All = Plus | Minus | Multiply | Division
}