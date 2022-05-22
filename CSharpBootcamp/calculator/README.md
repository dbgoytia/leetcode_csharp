Simple Calculator
=================


This is a starter program in the C# bootcamp. Goal is to build a Console application
that represents a simple Calculator.


Topics covered:
* String manipulation, formatting, etc.
* Converting types.
* Static vs non static methods.
* Exceptions and Throw Keywords.
* Try, catch finally.
* Unit testing.


-------------


Static methods
===============

Is a method defined as a member of an object, but is accessible directly from an API object's constructor, rather
than from an object instance created via the constructor. They are useful for methods that perform operations that
don't require any data from an instance of the class (from this), and can perform their intended purpose solely
using their arguments.

Example:

In the [Notifications API](https://developer.mozilla.org/en-US/docs/Web/API/Notifications_API), the Notification.requestPermission()
method is called on the actual Notification constructor itself - it is a static method:

```
let promise = Notification.requestPermission();
```

On the other hand, the Notification.close() method is an instance method - it is called on a specific notification object instance to
close the system notification it represents:

```
let myNotification = new Notification('This is my notification');

myNotification.close();

```

-------------


Unit testing results:

```
Test run for /Users/diego_canizales/Projects/leetcode_csharp/calculator/SimpleCalculator.Test.Unit/bin/Debug/netcoreapp3.1/SimpleCalculator.Test.Unit.dll (.NETCoreApp,Version=v3.1)
Microsoft (R) Test Execution Command Line Tool Version 16.11.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
  Passed AddsTwoNumbersAndReturnsValidResultForNonSymbolOperations [5 ms]
  Passed AddsTwoNumbersAndReturnsValidResultForSymbolOperations [< 1 ms]
  Passed SubstractsTwoNumbersAndReturnsValidResultForNonSymbolOperations [< 1 ms]
  Passed SubstractsTwoNumbersAndReturnsValidResultForSymbolOperations [< 1 ms]
  Passed MultipliesTwoNumbersAndReturnsValidResultForNonSymbolOperations [< 1 ms]
  Passed MultipliesTwoNumbersAndReturnsValidResultForSymbolOperations [< 1 ms]
  Passed DividesTwoNumbersAndReturnsValidResultForNonSymbolOperations [< 1 ms]
  Passed DividesTwoNumbersAndReturnsValidResultForSymbolOperations [< 1 ms]
  Passed ConvertsDoubleThrowsArgumentExceptionWhenGivenNonNumericValue [1 ms]
  Passed ConvertsStringToDoubleWhenGivenNumericValue [< 1 ms]

Test Run Successful.
Total tests: 10
     Passed: 10
 Total time: 0.8970 Seconds
       Done executing task "Microsoft.TestPlatform.Build.Tasks.VSTestTask".
   1:7>Done building target "VSTest" in project "SimpleCalculator.Test.Unit.csproj".
   1:7>Done Building Project "/Users/diego_canizales/Projects/leetcode_csharp/calculator/SimpleCalculator.Test.Unit/SimpleCalculator.Test.Unit.csproj" (VSTest target(s)).

Build succeeded.
    0 Warning(s)
    0 Error(s)
```