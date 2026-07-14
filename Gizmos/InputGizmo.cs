/**
 * Draw a path gizmo showing the movement of an object
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3.7
 */

using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputGizmo : MonoBehaviour
{
#region Enums
    public enum ActionType { Button, Axis, Vector2 };
    public enum AxisType { Horizontal, Vertical };
#endregion

#region Parameters
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private string mapName;
    [SerializeField] private string actionName;
    [SerializeField] private float size = 1;
    [SerializeField] private Color color = Color.green;
    [SerializeField] private AxisType axisDirection;
    [SerializeField] private Space space = Space.World;
#endregion

#region State
    private ActionType? actionType;
    private InputAction action;

    private bool buttonValue;
    private float axisValue;
    private Vector2 vector2Value;
#endregion

#region Init & Destroy
    void Awake()
    {
        InputActionMap map = inputActionAsset.FindActionMap(mapName);
        if (map == null) 
        {
            throw new ArgumentException($"{inputActionAsset.name} does not include the mapping 'mapName");
        }

        action = map.FindAction(actionName);
        if (action == null) 
        {
            throw new ArgumentException($"{inputActionAsset.name}.{mapName} does not include the action '{actionName}'");
        }

        actionType = null;

        switch (action.type)
        {
            case InputActionType.Button:
                actionType = ActionType.Button;
                break;

            case InputActionType.Value:
                foreach (ActionType t in ActionType.GetValues(typeof(ActionType)))
                {
                    if (action.expectedControlType.Equals(t.ToString()))
                    {
                        actionType = t;
                        break;
                    }
                }        
                break;

            case InputActionType.PassThrough:
                break;
        }

        if (actionType == null)
        {
            throw new ArgumentException(
                $"{inputActionAsset.name}.{mapName}.{actionName} has an unsuuported action / control type: {action.type} / {action.expectedControlType}");            
        }
    }
#endregion

#region Update
    void Update()
    {
        if (actionType == null)
        {
            return;

        }
        switch (actionType)
        {
            case ActionType.Button:
                buttonValue = action.IsPressed();
                break;

            case ActionType.Axis:
                axisValue = action.ReadValue<float>();
                break;

            case ActionType.Vector2:
                vector2Value = action.ReadValue<Vector2>();
                break;
        }
    }
#endregion

#region Gizmos
    void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            switch (actionType)
            {
                case ActionType.Button:
                    DrawButtonGizmo();
                    break;

                case ActionType.Axis:
                    DrawAxisGizmo();
                    break;

                case ActionType.Vector2:
                    DrawVector2Gizmo();
                    break;
            }
        }
    }

    private void DrawButtonGizmo()
    {
        Gizmos.color = color;

        Gizmos.DrawWireSphere(transform.position, size);
        if (buttonValue)
        {
            Gizmos.DrawSphere(transform.position, size * 0.9f);        
        }
    }

    private void DrawAxisGizmo()
    {
        Gizmos.color = color;

        Vector3 negPosition = Vector3.zero;
        Vector3 posPosition = Vector3.zero;

        Vector3 right = (space == Space.Self) ? transform.right : Vector3.right;
        Vector3 up = (space == Space.Self) ? transform.up : Vector3.up;

        switch (axisDirection)
        {
            case AxisType.Horizontal:
                negPosition = transform.position - right * size;
                posPosition = transform.position + right * size;
                break;

            case AxisType.Vertical:
                negPosition = transform.position - up * size;
                posPosition = transform.position + up * size;
                break;
        }
        Gizmos.DrawLine(negPosition, posPosition);
 
        Vector3 p = Vector3.Lerp(negPosition, posPosition, (axisValue + 1) / 2);
        Gizmos.DrawSphere(p, size * 0.1f);
    }

    private void DrawVector2Gizmo()
    {
        Gizmos.color = color;
        Vector3 v  = vector2Value;

        if (space == Space.Self)
        {
            v = transform.TransformDirection(v);
        }

        Vector3 p = transform.position + v;
        Gizmos.DrawLine(transform.position, p);
        Gizmos.DrawSphere(p, size * 0.1f);
    }


#endregion

}
