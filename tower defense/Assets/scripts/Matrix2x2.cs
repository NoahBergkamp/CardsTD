using UnityEngine;

public class Matrix2x2
{
    public float[,] Matrix { get; set; }

    public Matrix2x2(float a, float b, float c, float d)
    {
        Matrix = new float[2, 2] { { a, b }, { c, d } };
    }

    public float Determinant()
    {
        return Matrix[0, 0] * Matrix[1, 1] - Matrix[0, 1] * Matrix[1, 0];
    }

    public Vector3 Multiply(Vector3 vector)
    {
        float x = Matrix[0, 0] * vector.x + Matrix[0, 1] * vector.y;
        float y = Matrix[1, 0] * vector.x + Matrix[1, 1] * vector.y;
        return new Vector3(x, y, vector.z);
    }
}
