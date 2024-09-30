using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    [SerializeField] string transitionAreaName;
    
    void Start()
    {
        if (transitionAreaName == PlayerController.instance.transitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }
    }

    
    void Update()
    {
        
    }
}
