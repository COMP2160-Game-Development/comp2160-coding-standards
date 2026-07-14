
# C# Style Guide

(adapted from The Official raywenderlich.com C# Style Guide)
Version 2026.1 (13 Mar 2026)

Our overarching goals of this style guide are conciseness, readability and simplicity. Also, this guide is written to keep Unity in mind. This guide is based on C# and Unity conventions.

- [C# Style Guide](#c-style-guide)
- [Nomenclature](#nomenclature)
  - [Constants](#constants)
  - [Namespaces](#namespaces)
  - [Classes \& Interfaces](#classes--interfaces)
  - [Methods](#methods)
  - [Fields](#fields)
  - [Properties](#properties)
  - [Parameters](#parameters)
  - [Delegates](#delegates)
  - [Events](#events)
  - [Misc](#misc)
- [Declarations](#declarations)
  - [Access Level Modifiers](#access-level-modifiers)
  - [Fields \& Variables](#fields--variables)
  - [Classes](#classes)
  - [Interfaces](#interfaces)
- [Spacing](#spacing)
  - [Indentation](#indentation)
  - [Blocks](#blocks)
  - [Line Length](#line-length)
  - [Line Wraps](#line-wraps)
  - [Vertical Spacing](#vertical-spacing)
- [Brace Style](#brace-style)
  - [Switch Statements](#switch-statements)
- [Language](#language)
- [Nested calls](#nested-calls)
- [Unity specifics](#unity-specifics)
  - [Input Actions](#input-actions)
  - [Layers](#layers)
- [Regions](#regions)
  - [Declaration regions](#declaration-regions)
  - [Method regions](#method-regions)
- [Credits](#credits)
- [Version History](#version-history)
  - [2026.1](#20261)
  - [2023.1](#20231)
  - [2022.2](#20222)
  - [2021.1](#20211)
  - [2020.1](#20201)
 
# Nomenclature

On the whole, naming should follow C# standards:
* https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
* https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines

Names should be meaningful and express the purpose of the class, method or variable.

**AVOID:**
```
Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
RaycastHit h;
if (Physics.Raycast(r, out h, d))
{
    // …
}
```

**PREFER:**
```
Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
RaycastHit hit;
if (Physics.Raycast(ray, out hit, distance))
{
    // …
}
```

Single-letter variable names can be used for temporary numerical values in loop indices or mathematical equations, if this improves readability, but should be avoided otherwise.

## Constants

Numerical constants should be always be named. 

Universal constants (such as pi or tau) should be defined as const, and specified in PascalCase:

**AVOID:**
```
double x = Math.Cos(numberOfTurns * 6.2831853071);
```

**PREFER:**
```
const double Tau = 6.2831853071;
// ...
double x = Math.Cos(numberOfTurns * Tau);
```

Often constants are actually tunable parameters, in which case they should be turned into serialized fields, so they can be tuned in the Inspector:

**AVOID:**
```
if (Physics.Raycast(ray, out hit, 100))
{
    // …
}
```

**PREFER:**
```
// in class definition:
[SerializeField] private float laserRange = 100f;
// in method
if (Physics.Raycast(ray, out hit, laserRange))
{
    // …
}
```

Avoid using public fields for tunable parameters:

**AVOID:**
```
public float laserRange = 100f;
```

**PREFER:**
```
[SerializeField] private float laserRange = 100f;
```

## Namespaces

Namespaces are all PascalCase, multiple words concatenated together, without hyphens ( - ) or underscores ( _ ). The exceptions to this rule are acronyms like GUI or HUD, which can be uppercase:

**AVOID:**
```
com.raywenderlich.fpsgame.hud.healthbar
```

**PREFER:**
```
RayWenderlich.FPSGame.HUD.Healthbar
```

## Classes & Interfaces

Classes and interfaces are written in PascalCase. For example: 

```
public class PlayerMove : MonoBehaviour
```

## Methods

Methods are written in PascalCase. 

For example: 
```
private DoSomething() 
```

## Fields
All non-static fields are written camelCase. Per Unity convention, this includes public fields as well.

For example:
```
public class MyClass 
{
    public int publicField;
    int packagePrivate;
    private int myPrivate;
    protected int myProtected;
}
```

**AVOID:**
```
private int _myPrivateVariable
```

**PREFER:**
```
private int myPrivateVariable
```

Static fields are the exception and should be written in PascalCase:
```
public static int TheAnswer = 42;
```

## Properties

All properties are written in PascalCase. For example:
```
public int PageNumber 
{
    get { return pageNumber; }
    set { pageNumber = value; }
}
```

## Parameters

Parameters are written in camelCase.

**AVOID:**
```
void DoSomething(Vector3 Location)
```

**PREFER:**
```
void DoSomething(Vector3 location)
```

Single character values are to be avoided except for temporary looping variables.

## Delegates 

Delegates are written in PascalCase. For example:
```
    public delegate void PlayedDiedEventHandler();
```

## Events 

Events are written in PascalCase. For example:
```
public event PlayedDiedEventHandler OnPlayerDied;
```

## Misc

In code, acronyms should be treated as words. For example:

**AVOID:**
```
XMLHTTPRequestString URLfindPostByID
```

**PREFER:**
```
XmlHttpRequestString urlFindPostById
```
 
# Declarations

## Access Level Modifiers

Access level modifiers should be explicitly defined for classes, methods and member variables. All fields should be private. Tuneable fields should be serialized to make them available in the Inspector.

**AVOID:**
```
int tuneableParameter;
int internalStateVariable;
```

**PREFER:**
```
[SerializeField] private int tuneableParameter;
private int internalStateVariable;
```

## Fields & Variables

Prefer single declaration per line.

**AVOID:**
```
private string username, twitterHandle;
```

**PREFER:**
```
private string username;
private string twitterHandle;
```

## Classes

Exactly one class per source file, although inner classes are encouraged where scoping appropriate.

## Interfaces

All interfaces should be prefaced with the letter I.

**AVOID:**
```
public interface RadialSlider
```

**PREFER:**
```
public interface IRadialSlider
```
 
# Spacing

Spacing is especially important, as code needs to be easily readable.

## Indentation

Indentation should be done using spaces — never tabs.

## Blocks
Indentation for blocks uses 4 spaces for optimal readability:

**AVOID:**
```
for (int i = 0; i < 10; i++) 
{
  Debug.Log("index=" + i);
}
```

**PREFER:**
```
for (int i = 0; i < 10; i++) 
{
    Debug.Log("index=" + i);
}
```

## Line Length
Lines should be no longer than 100 characters long.

## Line Wraps
Lines longer than 100 characters should be laid out over multiple lines, with 4 space indentation. 

**AVOID:**
```
CoolUiWidget widget = someIncrediblyLongExpression(that, reallyWouldNotFit, onOneLine);
```

**PREFER:**
```
CoolUiWidget widget =
    someIncrediblyLongExpression(that, reallyWouldNotFit, onOneLine);
```

If it is necessary to move method parameters to separate lines, indent 8 characters:

**AVOID:**
```
CoolUiWidget widget =
    someIncrediblyLongExpression(that, still, doesnt, fit, on, a, single, line);
```

**PREFER:**
```
CoolUiWidget widget =
    someIncrediblyLongExpression(
        that, still, doesnt, fit, on, a, single, line);
```

Parameters should be placed on multiple lines if this improves clarity. For example:
```
CoolUiWidget widget =
    someIncrediblyLongExpression(
        that, still, doesnt, 
        fit, on, a, single, line);
```

## Vertical Spacing
There should be exactly one blank line between methods to aid in visual clarity and organization. Whitespace within methods should separate functionality but having too many sections in a method often means you should refactor into several methods.

# Brace Style

All braces get their own line as it is a C# convention:

**AVOID:**
```
class MyClass {
    void DoSomething() {
        if (someTest) {
            // ...
        } else {
            // ...
        }
    }
}
```

**PREFER:**
```
class MyClass
{
    void DoSomething()
    {
        if (someTest)
        {
            // ...
        }
        else
        {
            // ...
        }
    }
}
```

Conditional statements are always required to be enclosed with braces, irrespective of the number of lines required.

**AVOID:**
```
if (someTest)
    doSomething();

if (someTest) doSomethingElse();
```

**PREFER:**
```
if (someTest) 
{
    DoSomething();
}

if (someTest)
{
    DoSomethingElse();
}
```

## Switch Statements

Switch-statements come with default case by default (heh). If the default case is never reached, be sure to remove it.

**AVOID:**
```
switch (variable) 
{
    case 1:
        break;
    case 2:
        break;
    default:
        // THIS NEVER HAPPENS
        break;
}
```

**PREFER:**

```
switch (variable) 
{
    case 1:
        break;
    case 2:
        break;
}
```

# Language

Use US English spelling. Much of the API is written in US English and switching between US and UK is a likely source of errors.

**AVOID:**
```
Color colour = Color.red;
```

**PREFER:**
```
Color color = Color.red;
```

The exception here is MonoBehaviour as that's what the class is actually called.

# Nested calls

Avoid using nested method calls. Use temporary variables (with appropriate names) instead:

**AVOID:**
```
if (Physics.Raycast(Camera.main.ScreenPointToRay(
        Input.mousePosition), distance))
{
    // …
}
```

**PREFER:**
```
Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
if (Physics.Raycast(ray, distance))
{
    // …
}
```
 
# Unity specifics

Unity often uses string constants to access things configured in the Inspector. This is bad practice and is a common source of errors. Use a consistent naming scheme to mitigate this problem.

## Input Actions

Input actions and action maps should be named in PascalCase:

**AVOID:**
```
InputActionMap map = actions.FindActionMap(“UI Navigation”);
InputAction selectAction = map.FindAction(“select”);
```

**PREFER:**
```
InputActionMap map = actions.FindActionMap(“UINavigation”);
InputAction selectAction = map.FindAction(“Select”);
```

If possible, prefer using an autogenerated C# Actions class to avoid using string constants entirely: 

**PREFER:**
```
Actions actions = new Actions();
InputActionMap map = actions.UINavigation;
InputAction selectAction = actions.UINavigation.Select;
```

## Layers
Layers should be named using PascalCase. 
 
# Regions

Use regions to organise related declarations, and indicate when in the game loop they are being executed.

## Declaration regions

* `Parameters`
  * For serialized fields accessible in the Unity Inspector
* `Connected Objects`
  * For connecting to related objects
  * Serialized fields set up in the inspector should only be used for child objects connected in a prefab. 
  * Other objects should be connected using FindObjectByType in Awake
* `State`
  * For private state variables (except as below)
* `Components`
  * For components of this gameObject. These should be initialised using GetComponent in Awake
* `Properties`
  * For properties giving access to State variables
* `Events`
  * For declaring delegates and events.

## Method regions

* `Init & Destroy`
  * `Awake()`
  * `Start()`
  * `OnEnable()`
  * `OnDisable()`
  * `OnDestroy()`
  * Related private methods that are called from these.
* `Update`
  * `Update()`
  * Related private methods that are called from `Update`
* `FixedUpdate`
  * `FixedUpdate()`
  * `OnCollisionXXX()`
  * `OnTriggerXXX()`
  * Related private methods that are called from these.
* `Public methods`
  * Public methods that are called from other classes.
* `Event handlers`
  * Handlers for events this class is subscribed to.
* `Gizmos`
  * `OnDrawGizmos()`

# Credits
This style guide is based on the raywenderlich.com style guide, a collaborative effort from the most stylish raywenderlich.com team members:
* Darryl Bayliss
* Sam Davies
* Mic Pringle
* Brian Moakley
* Ray Wenderlich
* Eric Van de Kerckhove
  
# Version History

## 2026.1
* Updated by Malcolm Ryan.
* Added conventions for regions.

## 2023.1
* Updated by Malcolm Ryan.
* Added conventions for delegates and events.
* Added discussion of the new Unity Input Manager.

## 2022.2
* Reformatted by Malcolm Ryan. 
* Added SerializeField instead of public fields for tuneable parameters
* Added standard naming for layers.

## 2021.1
* Reformatted by Malcolm Ryan. 
* Added examples for access modifiers.
* Added standards for axes, buttons and keys

## 2020.1
* Adapted by Malcolm Ryan from the raywenderlich.com style guide.
