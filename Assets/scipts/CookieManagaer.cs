using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookieManagaer : MonoBehaviour
{
    [SerializeField] private int cookies =0;
    [SerializeField] private int cookiesPerClick = 1;
    [SerializeField] private Text cookieText;
    [SerializeField] private Text upgradeText;
    [SerializeField] private int autoCookies = 1;
    [SerializeField] private Button BuyAutoCookies;
    private bool boughtAutoClicker;





    //updates
    private int costToUpdate = 20;
    private int costToAdd = 40;


    //text updates every time the cookie is clicked
    public void Start()
    {
        UpdateCookieText();
        UpdateUpgradeText();
        BuyAutoCookies.interactable = false;
        boughtAutoClicker = false;
    }

    void Update()
    {
        if (cookies >= costToAdd && boughtAutoClicker==false)
        {
            BuyAutoCookies.interactable = true;
        }
        else if (cookies < costToAdd)
        {
            BuyAutoCookies.interactable = false;
        }

    }

    //upgrades cookies per click by time-sing cookies per click by 2
    public void AddCookie()
    {
        cookies += cookiesPerClick;

        UpdateCookieText();

    }

    public void AddAutoClicker()
    {
        if (cookies >= costToAdd)
        {
            cookies -= costToAdd;

            // Start Auto Clicker
            StartCoroutine(AutoClicker());

            UpdateCookieText();
            //updateAddText();
            boughtAutoClicker = true;
        }
    }


    private IEnumerator AutoClicker()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            AddCookie();
        }
    }
   

    public void UpgradeCookiesPerClick()
    {
        if (cookies >= costToUpdate)
        {
            cookies -= costToUpdate;
            cookiesPerClick++;
            costToUpdate = costToUpdate * 2;
            UpdateCookieText();
            UpdateUpgradeText();
        }
    }

    private void UpdateUpgradeText()
    {
        if(upgradeText != null)
        {
            upgradeText.text = "upgrade " + costToUpdate;
        }
    }



    private void UpdateCookieText()
    {

        if (cookieText != null)
        {
            cookieText.text = cookies.ToString();
        
            switch (cookies)
            {
                case 0:
                    cookieText.text = "No cookies";
                    break;
                case 1:
                    cookieText.text = "One cookie";
                    break;
                default:
                    cookieText.text = cookies + " cookies";
                    break;

            }

            
        }
        
        
    }
}
