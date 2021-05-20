using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMaterialProperty : MonoBehaviour
{
    
    public Material objectMaterial
    {
        get{
            return GetComponent<MeshRenderer>().material;
        }
    }

    public float m_materialFloat;
    public float materialFloat
    {
        get{
            return m_materialFloat;
        }
        set
        {
            m_materialFloat = value;
            SetMaterialProperty(value);
        }
    }
    public string materialPropertyName;
    public void SetMaterialProperty(float amount)
    {
        objectMaterial.SetFloat(materialPropertyName,amount);
    }
}
