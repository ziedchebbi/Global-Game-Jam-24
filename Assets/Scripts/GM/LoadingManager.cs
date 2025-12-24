using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingPannel;
    private Scene scene;

    void Awake() 
    {
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (!scene.isLoaded) loadingPannel.SetActive(true);
        if (scene.isLoaded) loadingPannel.SetActive(false);
    }
}
