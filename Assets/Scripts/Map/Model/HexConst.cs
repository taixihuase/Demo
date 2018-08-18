using UnityEngine;

public static class HexConst
{
    public const float outerRadius = 10f;
    public const float innerRadius = outerRadius * 0.866025404f;
    public static Color defaultColor = Color.white;

    public static Color[] colors =
    {
        defaultColor, defaultColor, defaultColor,
        defaultColor, defaultColor, defaultColor,
        defaultColor
    };

    public static Vector3[] vertices =
    {
        new Vector3(0f, 0f, outerRadius),
        new Vector3(innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(0f, 0f, -outerRadius),
        new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(0f, 0f, outerRadius)
    };

    public static Vector2[] uv =
    {
        new Vector2(0, 0),
        new Vector2(0, 1),
        new Vector2(1, 1),
        new Vector2(1, 0)
    };

    public static int[] triangles =
    {
        0, 1, 2,
        0, 2, 3,
        0, 3, 4,
        0, 4, 5,
        0, 5, 6,
        0, 6, 1
    };
}
