using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject 
{
    private string objectName;
    private string objectDescription;

    private int objectID;
    public enum ObjectTypes
    {
        OBJECTS,
        TICKETS,
        MISSIONS,
        LOCATIONS

    }
    private ObjectTypes objectType;

    public string ObjectName
    {
        get { return objectName; }

        set { objectName = value; }
    }

    public string ObjectDescription
    {
        get { return objectDescription; }

        set { objectDescription = value; }
    }

    public int ObjectID
    {
        get { return objectID; }

        set { objectID = value; }
    }
    public ObjectTypes ObjectType
    {
        get { return objectType; }

        set { objectType = value; }
    }
}
