using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour
{

    public void ChangeScene()
    {
        SceneManager.LoadScene("Night1");
    }
}
