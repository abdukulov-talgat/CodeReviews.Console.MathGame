using System.Diagnostics;
using System.Numerics;
using System.Reflection;

namespace abdukulov_talgat.MathGame.Core.Round;

public static class RoundFactory
{
    private static readonly Dictionary<Operation, Func<RoundBase>> OperationToCreatorFuncMap = [];

    static RoundFactory()
    {
        Type type = typeof(Operation);
        foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            if (IsBitMap(fieldInfo.GetValue(null))) continue;

            RoundCreatorAttribute? creatorAttribute = fieldInfo.GetCustomAttribute<RoundCreatorAttribute>();
            if (creatorAttribute is null) throw new InvalidOperationException("Creator attribute is missing!");
            OperationToCreatorFuncMap.Add(Enum.Parse<Operation>(fieldInfo.Name), creatorAttribute.GetCreator());
        }
    }

    private static bool IsBitMap(object? value)
    {
        Debug.Assert(value is not null);
        return !BitOperations.IsPow2((int)value);
    }

    public static RoundBase Create(Operation operationBitMap)
    {
        var chosenOperations = (from op in Enum.GetValues<Operation>()
                                where op != Operation.All && operationBitMap.HasFlag(op)
                                select op).ToList();

        Operation selectedOperation = chosenOperations[Random.Shared.Next(0, chosenOperations.Count)];
        return OperationToCreatorFuncMap[selectedOperation].Invoke();
    }
}