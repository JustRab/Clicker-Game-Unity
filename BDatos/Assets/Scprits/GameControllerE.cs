using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControllerE : MonoBehaviour
{
    public TMP_Text txt_clickCounter;
    public TMP_Text txt_time;
    public TMP_Text txt_record;
    public TMP_Text txt_info;
    public Button btn_click;
    public Button btn_reset;
    public Button btn_exit;
    public GameObject btn_resetObj;
    public GameObject btn_clickObj;
    private int clicks;
    private float time = 60;



    // Start is called before the first frame update
    void Start()
    {   
        txt_info.text =  "";
        clicks = 0;
        txt_record.text = "Record: " + PlayerPrefs.GetInt("recordE").ToString();
        txt_clickCounter.text = clicks.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
        time -= Time.deltaTime;
        txt_time.text = time.ToString("F2");
        }
        else
        {
            txt_time.text = "0.00";
            btn_clickObj.SetActive(false);
            btn_resetObj.SetActive(true);
            if(clicks > PlayerPrefs.GetInt("recordE"))
            {
                txt_info.text =  "Nuevo record";
                PlayerPrefs.SetInt("recordE", clicks);
                txt_record.text = "Record: " + PlayerPrefs.GetInt("recordE").ToString();
            }
            else
            {
                if(clicks < PlayerPrefs.GetInt("recordE"))
                {
                    txt_info.text = "No superaste tu record";
                }
            }
        }
    }

    public void Click()
    {
        clicks++;
        txt_clickCounter.text = clicks.ToString();
        
    }

    public void Reset()
    {
        txt_info.text = "";
        clicks = 0;
        txt_clickCounter.text = clicks.ToString();
        time = 60;
        btn_click.interactable = true;
        btn_resetObj.SetActive(false);
        btn_clickObj.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Level Select", LoadSceneMode.Single);
    }
}
