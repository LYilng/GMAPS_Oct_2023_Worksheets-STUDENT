using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;
    // Variable created for 2e to give vector3 value
    private Vector3 test;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX = 5, maxY = 5;

    private void Start()
    {
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(0, 0);
        endPt = new Vector2(2, 3);

        drawnLine = lineFactory.GetLine(startPt, endPt,
                                        0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude =" + vec2.magnitude);
    }

    void Question2b(int n)
    {
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            endPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            drawnLine = lineFactory.GetLine(startPt, endPt,
                                    0.02f, Color.black);
            drawnLine.EnableDrawing(true);

            Debug.Log("Lines printed");
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            // Your code here
            test = new Vector3(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY),
                Random.Range(-maxY, maxY));

            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                // Your code here,
                test,
                Color.white,
                60f);
        }
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2); // Your code here;
        // Vector for a + b
        HVector2D c = new HVector2D((a.x + b.x), (a.y + b.y));// Your code here;
        // Vector for a + -b
        HVector2D newC = new HVector2D(a.x + -b.x, a.y + -b.y);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
        // Draw b from zero
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        // Draw positive b from a to c
        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.green, 60f);
        // Draw negative b
        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);

        // Your code here
        // Line for a + b
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        // Line for a + -b
        DebugExtension.DebugArrow(Vector3.zero, newC.ToUnityVector3(), Color.white, 60f);

        // Your code here
        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of b = " + b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of c = " + c.Magnitude().ToString("F2"));
        // Your code here
        // ...
    }

    public void Question3b()
    {
        // Your code here
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(a.x * 2, a.y * 2);
        HVector2D halfA = new HVector2D(a.x / 2, a.y / 2);
        Vector3 offset = new Vector3(1, 0, 0);

        // Your code here
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(offset, b.ToUnityVector3(), Color.green, 60f);
        // A divided by 2
        DebugExtension.DebugArrow(offset, halfA.ToUnityVector3(), Color.green, 60f);
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D norA = new HVector2D(3, 5);
        Vector3 offset = new Vector3(1, 0, 0);

        norA.Normalize();

        Debug.Log("Magnitude of a = " + norA.Magnitude().ToString("F2"));

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(offset, norA.ToUnityVector3(), Color.green, 60f);
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;
        //Your code here
        float dotProduct = v1.DotProduct(c - a);
        HVector2D proj = v1.Projection(dotProduct / v1.DotProduct(v1)) + a;

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
