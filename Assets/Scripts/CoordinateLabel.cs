using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();
    Point point;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        point = GetComponentInParent<Point>();
        Display();
    }
    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            Display();
            ObjectName();
        }

        ToggleLabel();
        ColorCoordinate();
    }

    void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }

    void ColorCoordinate()
    {
        if (point.IsPlace)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void Display()
    {
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinate.x + "," + coordinate.y;
    }

    void ObjectName()
    {
        transform.parent.name = coordinate.ToString();
    }
}
