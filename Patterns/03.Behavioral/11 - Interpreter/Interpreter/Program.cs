using Interpreter;

Console.Title = "Interpreter";

List<RomanExpression> expressions =
[
    new RomanHunderdExpression(),
    new RomanTenExpression(),
    new RomanOneExpression(),
];

var context = new RomanContext(input: 5);

foreach (var expression in expressions)
{
    expression.Interpret(context);
}
Console.WriteLine($"Translating Arabic numerals to Roman numerals: 5 = {context.Output}");

context = new RomanContext(input: 81);

foreach (var expression in expressions)
{
    expression.Interpret(context);
}
Console.WriteLine($"Translating Arabic numerals to Roman numerals: 81 = {context.Output}");

context = new RomanContext(input: 733);

foreach (var expression in expressions)
{
    expression.Interpret(context);
}
Console.WriteLine($"Translating Arabic numerals to Roman numerals: 733 = {context.Output}");

Console.ReadKey();