using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    Material capsuleMaterial;

    void Init()
    {
        if (capsuleMaterial != null)
        {
            return;
        }

        var capsule = transform.GetChild(3).gameObject;
        var meshRenderer = capsule.GetComponent<MeshRenderer>();
        capsuleMaterial = new Material(meshRenderer.material);
        meshRenderer.material = capsuleMaterial;
    }

    public void SetColor(Color color)
    {
        Init();
        capsuleMaterial.SetColor("_Color", color);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
