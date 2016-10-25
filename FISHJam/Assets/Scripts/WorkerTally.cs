using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorkerTally : MonoBehaviour
{
    public float m_totalFrustration = 0.0f;
    public float m_totalSuspicion = 0.0f;

    public int m_toiletCount = 0;
    public int m_printerCount = 0;
    public int m_fridgeCount = 0;
    public int m_tableCount = 0;
    public int m_doorCount = 0;
    public int m_waterCount = 0;

    private int m_currentCount = 0;

    //WorkerUI slider variables
    public Slider m_frustrationSlider;
    public Slider m_suspicionSlider;

    public ParticleSystem m_annoyedParticles;

    void Awake()
    {
        m_annoyedParticles = gameObject.GetComponent<ParticleSystem>();
        m_annoyedParticles.Stop();

    }

    public void UpdateTally()
    {
        GameObject temp = gameObject.GetComponent<WorkerScript>().m_currentObject;
        m_totalFrustration += temp.GetComponent<ObjectInfo>().GetFrustration();
        m_totalSuspicion += temp.GetComponent<ObjectInfo>().GetSuspicion() * m_currentCount;
        IncrementCounter(temp.GetComponent<InteractableBase>().m_type);
    }

    public void Update()
    {
        //constantly update the value of the sliders
        m_frustrationSlider.value = m_totalFrustration;
        m_suspicionSlider.value = m_totalSuspicion;
        particleChange();
    }

    void IncrementCounter(InteractableManager.ObjectType _type)
    {
        switch (_type)
        {
            case InteractableManager.ObjectType.TOILET:
                {
                    m_toiletCount++;
                    m_currentCount = m_toiletCount;
                    break;
                }
            case InteractableManager.ObjectType.PRINTER:
                {
                    m_printerCount++;
                    m_currentCount = m_printerCount;
                    break;
                }
            case InteractableManager.ObjectType.FRIDGE:
                {
                    m_fridgeCount++;
                    m_currentCount = m_fridgeCount;
                    break;
                }
            case InteractableManager.ObjectType.TABLE:
                {
                    m_tableCount++;
                    m_currentCount = m_tableCount;
                    break;
                }
            case InteractableManager.ObjectType.DOOR:
                {
                    m_doorCount++;
                    m_currentCount = m_doorCount;
                    break;
                }
            case InteractableManager.ObjectType.WATERCOOLER:
                {
                    m_waterCount++;
                    m_currentCount = m_waterCount;
                    break;
                }
            default:
                {
                    m_currentCount = 0;
                    break;
                }
        }
    }

    //this function deals with the change of the particle effects
    void particleChange()
    {
        if(m_totalFrustration > 49)
        {
            if(m_annoyedParticles.isPlaying == false)
            {
                m_annoyedParticles.Play();
                //Debug.Log("PlayParticles");
            }
        }

        if(m_totalFrustration >= 60)
        {
            if (m_annoyedParticles.emissionRate < 30)
            {
                m_annoyedParticles.emissionRate = 40;
            }
        }

        if (m_totalFrustration >= 70)
        {
            if (m_annoyedParticles.emissionRate < 50)
            {
                m_annoyedParticles.emissionRate = 80;
            }
        }

        if (m_totalFrustration >= 80)
        {
            if (m_annoyedParticles.emissionRate < 80)
            {
                m_annoyedParticles.emissionRate = 120;
            }
        }

        if (m_totalFrustration >= 95)
        {
            if (m_annoyedParticles.emissionRate < 100)
            {
                m_annoyedParticles.emissionRate = 140;
            }
        }
    }
}
