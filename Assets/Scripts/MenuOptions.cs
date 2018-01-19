using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuOptions : MonoBehaviour {

    //private int numberless = 7;
    private int lathedAmmo;
    public TMP_Text profile_1_Day;
    

    public void Start()
    {
        //lathedAmmo = PlayerPrefs.GetInt("lathedAmmo");
        lathedAmmo = 7;
       /// profile_1_Day.text = "asdfas" + lathedAmmo;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }


}
