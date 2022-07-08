Console.WriteLine("Hello, World!");

var str = "()";
var str2 = "()[]{}";
var str3 = "()[}";
var str4 = "()}()";

Console.WriteLine(SolutionV2.IsValid(str) ? "ok" : "x");
Console.WriteLine(SolutionV2.IsValid(str2) ? "ok" : "x");
Console.WriteLine((!SolutionV2.IsValid(str3)) ? "ok" : "x");
Console.WriteLine((!SolutionV2.IsValid(str4)) ? "ok" : "x");

static class SolutionV1
{
    public static bool IsValid(string s)
    {
        var stack = new Stack<char>();
        char[] startingChars = new[] { '(', '{', '[' };
        char[] endingChars = new[] { '(', '{', '[' };
        foreach (char c in s)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
                continue;
            }
            if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0)
                    return false;
                char lastOpenChar = stack.Pop();
                if (
                    (c == ')' && lastOpenChar != '(')
                    || (c == '}' && lastOpenChar != '{')
                    || (c == ']' && lastOpenChar != '[')
                )
                    return false;
            }
        }
        return stack.Count == 0;
    }
}

static class SolutionV2
{
    public static bool IsValid(string s)
    {
        var stack = new Stack<char>();
        Dictionary<char, char> charPairsDictionary = new Dictionary<char, char>() { { ')', '(' }, { ']', '[' }, { '}', '{' } };
        foreach (char c in s)
        {
            if (!charPairsDictionary.ContainsKey(c))
            {
                stack.Push(c);
                continue;
            }

            if (stack.Count == 0 || charPairsDictionary[c] != stack.Pop())
                return false;
        }
        return stack.Count == 0;
    }
}