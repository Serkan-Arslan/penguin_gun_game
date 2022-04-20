using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class penguin_control : MonoBehaviour
{
    public GameObject penguin;
    public GameObject born_point;
    public List<GameObject> penguin_list;
    public Text skor;
    public int power;
    public Vector3 hiz;
    public Button restart_buton;
    public GameObject top;
    public Joystick joystick;
    public double guc_carpani=0;
    public bool guc_bool=false;
    public Image guc_resim;
    public Button ates_buton;
    public GameObject patlama_effect;
    public float bonus_x;
    public float bonus_y;
    public float bonus_z;
    public GameObject bonus_top;
    public Camera cam1;
    public Camera cam2;

    private void Awake()
    {
        bonus_x = Random.Range(-15, 11);
        bonus_y = Random.Range(5, 30);
        bonus_z = Random.Range(-18, -5);
    }

    void Start()
    {
        penguin_list = new List<GameObject>();

        Instantiate(bonus_top,new Vector3(bonus_x,bonus_y,bonus_z),Quaternion.identity);
        
    }

    float vertical;
    float horizontal;
    // Update is called once per frame
    void Update()
    {
        vertical =-1* joystick.Vertical;
        horizontal=joystick.Horizontal;
        
        if(vertical>0.2 || vertical<-0.2)
        {
            Debug.Log(top.transform.rotation.z);
            if (vertical*-1>0 && top.transform.rotation.z>-0.5)
            {
                top.transform.Rotate(0, 0, 2 * vertical);
                
            }
            else if (vertical*-1 < 0 && top.transform.rotation.z < 0.15)
            {
                top.transform.Rotate(0, 0, 2 * vertical);

            }

        }
        if (horizontal>0.2 && top.transform.position.z < 0)
        {
            top.transform.Translate(0, 0, (float)0.2 * horizontal);
            
        }
        else if (horizontal<-0.2 && top.transform.position.z > -17)
                {
            top.transform.Translate(0, 0, (float)0.2 * horizontal);

        }

        if (penguin_list.Count > 0)
        {
            hiz = penguin_list[penguin_list.Count - 1].GetComponent<Rigidbody>().velocity;
        }
        if (penguin_list.Count ==11 ) 
        {
            skor.gameObject.SetActive(true);
            string skor_var = "Skorunuz:" + " " + etkilesim.etkilesim_liste.Count.ToString();
            skor.text = skor_var;
            restart_buton.gameObject.SetActive(true);
            //ates_buton.gameObject.SetActive(false);
        
        }
        if (guc_carpani < 1 && guc_bool==true)
        {
            guc_carpani = guc_carpani + 0.3 * Time.deltaTime;
        }

        else if (guc_carpani > 0 && guc_bool==false)
        {
            guc_carpani -= 1 * Time.deltaTime;
        }
        else
        {
            guc_carpani = 0;
        }

        
        guc_resim.GetComponent<Image>().fillAmount = (float)guc_carpani;
    }

    public void Penguin_create()
    {
        if (penguin_list.Count < 11)
        {
            GameObject penguin_ins = Instantiate(penguin, born_point.transform.position, Quaternion.Euler(0,0,45));
            Instantiate(patlama_effect, born_point.transform.position, Quaternion.identity);
            penguin_list.Add(penguin_ins);
            penguin_list[penguin_list.Count - 1].GetComponent<Rigidbody>().AddForce(born_point.transform.forward * power*(float)guc_carpani);
        }

    }

    public void restartlama()
    {
        SceneManager.LoadScene(0);
        
        penguin_list.Clear();
        
    }
    public void guc_artirma()
    {
        guc_bool = true;
    }
    public void atesleme()
    {
        guc_bool = false;
        Penguin_create();



    }
    public void diger_aci()
    {
        if (cam1.gameObject.activeSelf)
        {
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);

        }
        else if (cam2.gameObject.activeSelf)
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);

        }

    }
}
