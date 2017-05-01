# New features in C# 7

> Test suite of new features in C# 7

This repo contains a list of new features in C# 7. Examples are heavily influenced from [StackOverflow documentation](http://stackoverflow.com/documentation/c%23/1936/c-sharp-7-0-features#t=201704181446063259477) as well as [this MSDN blog post](https://blogs.msdn.microsoft.com/dotnet/2016/08/24/whats-new-in-csharp-7-0/).

## Topics covered

* [Binary Literals](https://github.com/pardahlman/csharp-seven/blob/master/CsharpSeven/BinaryLiterals.cs)
* [Local Functions](https://github.com/pardahlman/csharp-seven/blob/master/CsharpSeven/LocalFunctions.cs)
* [`out var` declarations](https://github.com/pardahlman/csharp-seven/blob/master/CsharpSeven/OutVarDeclaration.cs)
* [Pattern Matching](https://github.com/pardahlman/csharp-seven/blob/master/CsharpSeven/PatternMatching.cs)
* [`ref local` and `ref return`](https://github.com/pardahlman/csharp-seven/blob/master/CsharpSeven/RefLocalAndRefReturn.cs)
* [Throwing exceptions](https://github.com/pardahlman/csharp-seven/blob/master/CsharpSeven/ThrowExceptions.cs)
* [Tuples](https://github.com/pardahlman/csharp-seven/blob/master/CsharpSeven/Tuples.cs)
* [ValueTask](https://github.com/pardahlman/csharp-seven/blob/master/CsharpSeven/ValueTask.cs)

## Examples

Introduces object deconstruction, expression bodies and `ValueTuples`

```csharp
class Person
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public (string First, string Last) FullName => (FirstName, LastName);

	public void Deconstruct(out string first, out string last)
	{
		first = FirstName;
		last = LastName;
	}
}
```
