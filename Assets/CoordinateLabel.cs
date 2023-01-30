using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
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
