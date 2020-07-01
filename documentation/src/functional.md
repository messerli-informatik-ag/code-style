# Functional Programming

## Immutability

While only data can have side effects, it is the methods and functions, which profit the most of immutability. They are much easier to understand and usually the code is much more elegant when you stay away from mutability. A function f in program P has no side-Effect if `f() == f()` for all states of P. In addition, the state of P does not change if you invoke f.
Programs without side effects are easy to test because it implies that any test of f is independent of the state of P.

### Prefer immutable types to mutable ones

An immutable type can only set its state through a constructor. No stateful setters are allowed on an immutable type. Changing state is done through transformation by copying. This way, even a setter can be written in an immutable way:

## Use higher-order functions with LINQ and avoid writing your own for-loops

We try to avoid unnecessary repetition. For many things, there are generic algorithms. Use LINQ and other Algorithms to create powerful abstractions.
If there is not an algorithm available, try to be generic and write your own algorithms.

| Task             | LINQ                                                     |
|------------------|----------------------------------------------------------|
| Projection       | Select, SelectMany                                       |
| Aggregation      | Aggregate, Sum, Min, Max, Average, Count                 |
| Restriction      | Where                                                    |
| Existence        | Any, All, Contains, Distinct                             |
| Set Operations   | Contains, Distinct, Union, Intersect, Except             |
| Sorting          | OrderBy, ThenBy, OrderByDescending, ThenByDescending     |
| Paging           | First, Last, Single, Skip, Take, SkipWhile, TakeWhile    |
| String Formating | `string.Format()` or use `$""` (String interpolation)    |

### LINQ syntax

Extension Methods and LINQ syntax are equivalent. Both have their up- and down-sides. Chose the one which you think is most appropriate for the Task at hand. You can also mix them in the same code file if it makes the code easier to read.

## Use the import of static functions to your advantage

With the ability to import static functions, the syntax is much more natural to call functions on their own. Use that to your advantage and write free functions independent of any type.
