using System;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentLibrary : MonoBehaviour
{

    public List<ViewConfiguration> m_views = null;
    
    
    private int currentViewIndex = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
