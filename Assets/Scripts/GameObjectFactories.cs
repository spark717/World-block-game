using UnityEngine;


public enum XYZdirection
{
    X,
    Y,
    Z
}



public enum XYZplane
{
    XY,
    XZ,
    YZ
}



public abstract class InstantiateWithParameters
{
    public GameObject Prefab { protected get; set; }
    public Transform Parent { protected get; set; }
    public string BasicName { protected get; set; }
    public Vector3 StartPosition { protected get; set; }
    public Quaternion Rotation { protected get; set; }

    protected void SetParent(GameObject go)
    {
        if (Parent != null)
            go.transform.SetParent(Parent);
    }

    protected virtual void SetRotation(GameObject go)
    {
        go.transform.rotation = Rotation;
    }

    protected void SetDefaultValues()
    {
        BasicName = "noname";
        StartPosition = Vector3.zero;
        Rotation = Quaternion.identity;
    }

    public abstract void Create();
}





public class InstantiateGameObject : InstantiateWithParameters
{
    public GameObject GO { get; private set; }

    public InstantiateGameObject()
    {
        SetDefaultValues();
    }


    public override void Create()
    {
        if (Prefab == null)
            return;

        var go = GameObject.Instantiate(Prefab);

        SetName(go);
        SetPosition(go);
        SetRotation(go);
        SetParent(go);
        GO = go;
    }

    
    protected void SetName(GameObject go)
    {
        go.name = BasicName;
    }


    protected void SetPosition(GameObject go)
    {
        go.transform.position = StartPosition;
    }
}





public class InstantiateGameObjectsM1 : InstantiateWithParameters
{
    public int Length { protected get; set; }
    public float Distance { protected get; set; }
    public XYZdirection Direction { private get; set; }
    public GameObject[] GOMassive { get; private set; }

    public InstantiateGameObjectsM1()
    {
        SetDefaultValues();
        Direction = XYZdirection.X;
    }


    public override void Create()
    {
        if (Length == 0 || Distance == 0 || Prefab == null) 
            return;

        GOMassive = new GameObject[Length];

        for (int i = 0; i < Length; i++)
        {
            var go = GameObject.Instantiate(Prefab);
            SetName(go, i);
            SetPosition(go, i);
            SetRotation(go);
            SetParent(go);
            GOMassive[i] = go;
        }
    }


    protected void SetName(GameObject go, int i)
    {
        go.name = BasicName + " " + i;
    }


    protected void SetPosition(GameObject go, int i)
    {
        var xpos = StartPosition.x;
        var ypos = StartPosition.y;
        var zpos = StartPosition.z;
        float im = i * Distance;

        switch (Direction)
        {
            case XYZdirection.X:
                xpos += im;
                break;
            case XYZdirection.Y:
                ypos += im;
                break;
            case XYZdirection.Z:
                zpos += im;
                break;
        }

        go.transform.position = new Vector3(xpos, ypos, zpos);
    }   
}





public class InstantiateGameObjectsM2 : InstantiateWithParameters
{
    public int Widht { protected get; set; }
    public int Length { protected get; set; }
    public float Distance { protected get; set; }

    public XYZplane Plane { protected get; set; }
    public GameObject[,] GOMassive { get; private set; }


    public InstantiateGameObjectsM2()
    {
        SetDefaultValues();
        Plane = XYZplane.XZ;
    }

    public override void Create()
    {
        if (Widht == 0 || Length == 0 || Distance == 0 || Prefab == null)
            return;

        GOMassive = new GameObject[Widht, Length];

        for (int i = 0; i < Widht; i++)
        {
            for (int j = 0; j < Length; j++)
            {
                var go = GameObject.Instantiate(Prefab);
                SetName(go, i, j);
                SetPosition(go, i, j);
                SetRotation(go);
                SetParent(go);
                GOMassive[i, j] = go;
            }
        }
    }


    private void SetPosition(GameObject go, int i, int j)
    {
        var xpos = StartPosition.x;
        var ypos = StartPosition.y;
        var zpos = StartPosition.z;
        float im = i * Distance;
        float jm = j * Distance;
        
        switch (Plane)
        {
            case XYZplane.XY:
                xpos += im;
                ypos += jm;
                break;
            case XYZplane.XZ:
                xpos += im;
                zpos += jm;
                break;
            case XYZplane.YZ:
                zpos += im;
                ypos += jm;
                break;
        }

        go.transform.position = new Vector3(xpos, ypos, zpos);
    }


    protected void SetName(GameObject go, int i, int j)
    {
        go.name = BasicName + " " + i + "," + j;
    }
}





public class InstantiateGameObjectsM3 : InstantiateWithParameters
{
    public int Widht { protected get; set; }
    public int Length { protected get; set; }
    public int Height { protected get; set; }
    public float Distance { protected get; set; }
    public GameObject[,,] GOMassive { get; private set; }


    public InstantiateGameObjectsM3()
    {
        SetDefaultValues();
    }

    public override void Create()
    {
        if (Widht == 0 || Length == 0 || Height == 0 || Distance == 0 || Prefab == null)
            return;

        GOMassive = new GameObject[Widht, Length, Height];

        for (int i = 0; i < Widht; i++)
        {
            for (int j = 0; j < Length; j++)
            {
                for (int k = 0; k < Height; k++)
                {
                    var go = GameObject.Instantiate(Prefab);
                    SetName(go, i, j, k);
                    SetPosition(go, i, j, k);
                    SetRotation(go);
                    SetParent(go);
                    GOMassive[i, j, k] = go;
                }
            }
        }
    }


    private void SetPosition(GameObject go, int i, int j, int k)
    {
        var xpos = StartPosition.x + i * Distance;
        var ypos = StartPosition.y + j * Distance;
        var zpos = StartPosition.z + k * Distance;

        go.transform.position = new Vector3(xpos, ypos, zpos);
    }


    protected void SetName(GameObject go, int i, int j, int k)
    {
        go.name = BasicName + " " + i + "," + j + "," + k;
    }
}