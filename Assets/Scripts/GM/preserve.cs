using UnityEngine;

public class preserve : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform);
    }
}
