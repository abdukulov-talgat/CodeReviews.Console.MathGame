using System.Diagnostics;
using System.Reflection;

namespace abdukulov_talgat.MathGame.Core.Round;

[AttributeUsage(AttributeTargets.Field)]
public class RoundCreatorAttribute : Attribute
{
    private const string FactoryMethodName = "Create";

    private readonly Type _factoryType;

    public RoundCreatorAttribute(Type factoryType)
    {
        Debug.Assert(factoryType.IsSubclassOf(typeof(RoundBase)));
        _factoryType = factoryType;
    }

    public Func<RoundBase> GetCreator()
    {
        MethodInfo? methodInfo = _factoryType.GetMethod(FactoryMethodName);

        return methodInfo is not null
            ? methodInfo.CreateDelegate<Func<RoundBase>>()
            : throw new InvalidOperationException($"{_factoryType.Name} doesn't have static method with name Create()");
    }
}