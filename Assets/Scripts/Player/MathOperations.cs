using UnityEngine;

public static class MathOperations
{
    public static Vector3 Normalize(Vector3 vector)
    {
        float magnitude = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        if (magnitude <= 0)
        {
            return Vector3.zero;
        }

        return vector / magnitude;
    }
}
