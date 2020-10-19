# Algebraic Datatypes

Algebraic datatypes are also called discriminated unions, tagged unions, and sometimes "or types" colloquially. 
They can be found in many functional languages (even if they're not named algebraic datatypes specifically), and have become widely known and used in Typescript 2.0.

## Algebraic datatypes in C#

While we don't have language support for algebraic datatypes in C#, there are some patterns on how you can implement something that behaves like one.

We recommend the usage of the following pattern using an abstract base class with a private constructor and inner, deriving classes and usually a match function.
This has the advantage that the algebraic options are namespaced as the inner class, which simplifies the naming.

When your intention is to write something like an enum, but with attachable data to every option, algebraic datatypes is what you're looking for.

## Example 1 (`ServiceStatus`)

Our example has 3 states - a service can be stopped, starting or running. Each state also provides the `StandardOutput` and the `StandardError`.
Our match method allows us to define what should happen for each configured option.
The upside of that over a switch expression is that we have no problems with exhaustability (see Example 2).

```csharp
public abstract class ServiceStatus
{
	private ServiceStatus(Process? process)
	{
		StandardOutput = process?.StandardOutput.ReadToEnd() ?? string.Empty;
		StandardError = process?.StandardError.ReadToEnd() ?? string.Empty;
	}

	public string StandardOutput { get; }

	public string StandardError { get; }

	public abstract void Match(
		Action<string, string> stopped,
		Action<string, string> starting,
		Action<string, string> running);

	public sealed class Stopped : ServiceStatus
	{
		public Stopped(Process? process)
			: base(process)
		{
		}

		public override void Match(
			Action<string, string> stopped,
			Action<string, string> starting,
			Action<string, string> running)
			=> stopped(StandardOutput, StandardError);
	}

	public sealed class Starting : ServiceStatus
	{
		public Starting(Process? process)
			: base(process)
		{
		}

		public override void Match(
			Action<string, string> stopped,
			Action<string, string> starting,
			Action<string, string> running)
			=> starting(StandardOutput, StandardError);
	}

	public sealed class Running : ServiceStatus
	{
		public Running(Process? process)
			: base(process)
		{
		}

		public override void Match(
			Action<string, string> stopped,
			Action<string, string> starting,
			Action<string, string> running)
			=> running(StandardOutput, StandardError);
	}
}
```

Summed up:
- Abstract class (ensures inner classes are always used in a namespaced manner, e.g. `ServiceStatus.Stopped`)
- Private constructor in abstract class (this ensures no one can derive from the abstract class except the inner classes)
- An abstract match method with an `Action` (or `Action<T1,...,Tn>`) for every option of the algebraic datatype
- Inner deriving sealed classes (that implement match and call the base constructor)

## Example 2 - why we recommend a match method

Consider the `ServiceStatus` algebraic datatype from Example 1.

Usage example with Match:

```csharp
status.Match(
	(output, error) => Console.WriteLine($"{output}, {error}"),
	(output, error) => Console.WriteLine($"{output}, {error}"),
	(output, error) => Console.WriteLine($"{output}, {error}"));
```

Usage example with switch expression:

```csharp
status switch
{
	ServiceStatus.Running running => Console.WriteLine($"{running.StandardOutput}, {running.StandardError}"),
	ServiceStatus.Starting starting => Console.WriteLine($"{starting.StandardOutput}, {starting.StandardError}"),
	ServiceStatus.Stopped stopped => Console.WriteLine($"{stopped.StandardOutput}, {stopped.StandardError}"),
	_ => throw new Exception("Unreachable"), // we need this, because the compiler doesn't know there's only 3 types
};
```

The advantage of using a match function is clear: 
No useless exception that is unreachable anyways, and immediate feedback from the compiler when adding another option to the algebraic datatype.