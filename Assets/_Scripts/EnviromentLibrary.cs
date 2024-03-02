using System;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentLibrary : MonoBehaviour
{

    public List<ViewConfiguration> m_views = null;
    
    
    // Start is called before the first frame update
}


[Serializable]
public class NavigationElement
{
    public GameObject element; // The UI element GameObject
    public int targetViewIndex; // Index of the view this element should switch to
}

[Serializable]
public class ViewConfiguration
{
    public Texture skyboxTexture; // Texture for the Skybox
    public List<NavigationElement> navigationElements; // Navigation elements for this view
}
