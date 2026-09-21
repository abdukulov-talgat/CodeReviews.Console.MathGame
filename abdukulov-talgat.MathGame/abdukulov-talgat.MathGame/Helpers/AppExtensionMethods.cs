using System.ComponentModel;
using System.Reflection;
using abdukulov_talgat.MathGame.Core;

namespace abdukulov_talgat.MathGame.Helpers;

public static class AppExtensionMethods
{
    extension(Operation op)
    {
        public string GetDescription()
        {
            Type type = op.GetType();

            if (Enum.GetName(op) is { } name
                && type.GetField(name) is { } fieldInfo
                && fieldInfo.GetCustomAttribute<DescriptionAttribute>() is { } attribute)
                return attribute.Description;

            return op.ToString();
        }
    }

    extension(string)
    {
        public static string PadCenter(string str = "", int totalWidth = -1, char paddingChar = '*')
        {
            if (totalWidth == -1) totalWidth = Console.WindowWidth;
            if (totalWidth <= str.Length) return str;

            int padLeft = (totalWidth - str.Length) / 2;
            return str.PadLeft(padLeft + str.Length, paddingChar).PadRight(totalWidth, paddingChar);
        }
    }
}