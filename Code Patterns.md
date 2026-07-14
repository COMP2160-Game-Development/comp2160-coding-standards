# Code Patterns

Standard coding patterns to use.

- [Code Patterns](#code-patterns)
- [Initialisation](#initialisation)
- [State \& Properties](#state--properties)
- [Actions](#actions)
- [String constants - Tags and Layers](#string-constants---tags-and-layers)
- [Odin Inspector attributes](#odin-inspector-attributes)
  - [Validation](#validation)
    - [Required](#required)
    - [ChildGameObjectsOnly](#childgameobjectsonly)
  - [Types](#types)
  - [Unit](#unit)
- [Version History](#version-history)
- [2026.1](#20261)


# Initialisation

As a general principle, avoid requiring any by-hand configuration in the Inspector, including setting fields on components or connecting objects together. If a behaviour expects a certain component property to be set, it should be done in code. 

An exception to this is connecting related objects within the same prefab. E.g. a UIMananger prefab may include links to various UI elements that are children within the prefab. These can be connected by hand when the prefab is constructed. They should be tagged with the `[Required]` and `[ChildGameObjectsOnly]` attributes.

An object should be initialised in `Awake()` including:
* Getting and storing relevant components, using `GetComponent`. An appropriate `[RequireComponent]` tag should be included for each.
* Getting and storing references to other objects in the scene (e.g. managers) using `FindAnyObjectByType`.
* Setting expected paramters on components (e.g. disabling gravity on a rigidbody)
* Subscribing to events on other objects.
* Setting up input actions

**EXAMPLE**
```
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
#region Components
    private Rigidbody2D rigidbody;
#endregion

#region Connected Objects
    private GameManager gameManager;

    // Gun is a child object in the Player prefab, connected by hand
    [SerializeField, Required, ChildGameObjectsOnly] private Transform gun;
#endregion

#region State
    private Actions actions;
#endregion

#region Init & Destroy
    void Awake()
    {
        actions = new Actions();

        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0; // disable gravity

        gameManager = FindAnyObjectByType<GameManager>();
        gameMananger.OnGameStarted += OnGameStarted;
    }
#endregion
}
```

# State & Properties

All state variables should be private. Properties can be used to provide public access, if necessary. Properties should have the same name as the corresponding state variable. Read-only properties should be implemented using 'fat-arrow' format:

PREFER:
```
private float size;
public float Size => size;
```

AVOID:
```
public float size;
```

AVOID:
```
private float size;
public float Size { get { return size; } }
```

# Actions

All input should be done using the Input System, not the obsolete Input Manager.

The **Generate C# Class** option should be set on the Input Action asset. The generated C# class should be used to access specific InputActions. A new Actions object should be created in the `Awake` method of a class that handles input. 

Input Action maps should be named according to the Monobehaviour that uses them, and should be activated in `OnEnable` and `OnDisable`. Avoid using the same mapping in different Monobehaviours as this may cause enabling/disabling to get out of sync.

Use input events or polling as appropriate.

**EXAMPLE**
```
public class PlayerMove : MonoBehaviour
{
#region State
    private Actions actions;
#endregion

#region Init & Destroy
    void Awake()
    {
        actions = new Actions();
        actions.Player.Jump.performed += (ctx) => { wasJumpPressed = true; };
    }

    void OnEnable() 
    {
        actions.PlayerMove.Enable();
    }

    void OnDisable() 
    {
        actions.PlayerMove.Disable();
    }
#endregion

#region Update
    void Update()
    {
        Vector2 move = Actions.Player.Move.ReadValue<Vector2>();
        // ...    
    }
#endregion
}
```

# String constants - Tags and Layers

Avoid using any string constants in code, e.g. when referring to Tags or Layers, as these are an easy source of errors that won't be detected at compile time. Instead, create `Tags` and `Layers` classes that define named constants for these strings, and use these constants elseswhere in code, so there is only one place to check.

Use `gameObject.CompareTag(tag)` instead of `gameObject.tag == tag`.

**EXAMPLE**
```
public class Tags
{
#region Constants
    public const string MainCamera = "MainCamera";
    public const string Player = "Player";
    public const string Coin = "Coin";
#endregion
}

public class PlayerMove : MonoBehaviour
{
#region Update
    void void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(Tags.Coin))
        {
            // ...
        }
    }
#endregion
}
```

# Odin Inspector attributes

Use [Odin Inspector](https://odininspector.com/attributes) attibutes to give more information about parameter values.

## Validation

### Required

Use the `[Required]` attribute to indicate fields which need to be set to non-null values in the Inspector. However see the [point above](#initialisation) about avoiding by-hand initialisation whenever possible.

### ChildGameObjectsOnly

Use the `[ChildGameObjectsOnly]` attribute when connecting objects by hand in the Inspector, to ensure that objects exist within the same prefab.

**EXAMPLE**
```
public class UIManager : MonoBehaviour
{
#region Child Objects
    [Header("Score Panel")]
    [SerializeField, Required, ChildGameObjectsOnly] private GameObject gamePanel;
    [SerializeField, Required, ChildGameObjectsOnly] private TMP_Text gameScoreText;
    [SerializeField, Required, ChildGameObjectsOnly] private TMP_Text gameHighscoreText;
#endregion
}
```

## Types

## Unit

Use the `[Unit]` tag to indicate the units for a parameter, e.g. metres, seconds, degress etc.

**EXAMPLE**
```
[SerializeField, Unit(Units.Seconds)] private float cooldownDuration = 10;
```

# Version History

# 2026.1

* First draft by Malcolm Ryan