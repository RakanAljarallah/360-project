using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
   [SerializeField] private  EnviromentLibrary enviromentLibraru;
   [SerializeField] private FadeController _fadeController;
   
   
   public  Material skyboxMaterial;

   private static int m_enviromentIndex = 0;

   public  int EnviromentIndex
   {
       get { return m_enviromentIndex; }
       set
       {
           print(value + " value");
           LoadEnviroment(value);
           m_enviromentIndex = value;
       }
   }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void LoadEnviroment(int enviromentIndex)
    {
       
        if (enviromentIndex >= 0 && enviromentIndex < enviromentLibraru.m_views.Count && skyboxMaterial != null)
        {
            skyboxMaterial.SetTexture("_MainTex", enviromentLibraru.m_views[enviromentIndex].skyboxTexture);
            
            _fadeController.ChangeViewWithFade();
            
            DynamicGI.UpdateEnvironment();

            // First, disable all current navigation elements
            if (m_enviromentIndex != -1)
            {
                foreach (var navElement in enviromentLibraru.m_views[m_enviromentIndex].navigationElements)
                {
                    navElement.element.SetActive(false);
                }
            }

            // Then, setup and enable navigation elements for the new view
            foreach (var navElement in enviromentLibraru.m_views[enviromentIndex].navigationElements)
            {
                navElement.element.SetActive(true);
                // Setup interaction events here, for example:
                // Assume each element has a component that listens for interaction and calls back to this manager
                SetupInteractiveElement(navElement);
            }
        }
    }
    
    private void SetupInteractiveElement(NavigationElement navElement)
    {
        // Assuming a component that handles the interaction, like 'NavigationElementInteractor'
        var interactor = navElement.element.GetComponent<InteractiveElement>();
        if (interactor != null)
        {
            interactor.Initialize(this, navElement.targetViewIndex);
        }
    }
}
