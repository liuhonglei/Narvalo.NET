Code Contracts
==============

Preconditions
-------------

Preconditions that will survive in Release mode:
- `Narvalo.Require`: Code Contract + Throws on failure
- `Narvalo.Require.Unproven`: Throws on failure (if CC can't handle the situation)

Preconditions that will not survive in Release mode:
- `Narvalo.Demand`: Code Contract + Debug.Assert
- `Narvalo.Demand.Unproven`: Debug.Assert (if CC can't handle the situation)

```csharp
public class MyClass {
  public void PublicMethod(string value) {
    Require.NotNull(value, nameof(value));

    // Code that calls at least
    // - one public/internal method from another object
    // - or one private/protected/internal method from this object
    // that requires value not to be null.
    OtherObject.PublicMethod(value);
    OtherObject.InternalMethod(value);
    InternalMethod(value);
    ProtectedMethod(value);
    PrivateMethod(value);
  }

  public void PublicMethod2(string value) {
    Demand.NotNull(value);

    // Code that only calls public methods.
    OtherObject.PublicMethod(value);
    PublicMethod(value);
  }

  internal void InternalMethod(string value) {
    Demand.NotNull(value);
  }

  protected virtual void ProtectedVirtualMethod(string value) {
    Demand.NotNull(value);
  }

  protected void ProtectedMethod(string value) {
    Demand.NotNull(value);
  }

  private void PrivateMethod(string value) {
    Demand.NotNull(value);
  }
}
```

```csharp
public class DerivedClass : MyClass {
  protected override void ProtectedVirtualMethod(string value) {
    // Same contract as the overriden method. Nothing to do.
  }
}
```

**TODO:** Abstract classes.

Postconditions
--------------

```csharp
using static System.Diagnostics.Contracts.Contract;

Ensures(Result<string>() != null);
```

Check points
------------

None of these assertions that will not survive in Release mode:
- `Narvalo.Check`: Code Contract + Debug.Assert
- `Narvalo.Check.Unproven` Debug.Assert (if CC can't handle the situation)

Invariants
----------
