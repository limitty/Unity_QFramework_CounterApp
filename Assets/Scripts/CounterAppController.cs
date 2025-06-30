using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterAppController : MonoBehaviour
{
    // View
    private Button mBtnAdd;
    private Button mBtnSub;
    private Text mCountText;
    
    // Model
    private int mCount = 0;
    
    void Start()
    {
        // Get UI components
        mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
        mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
        mCountText = transform.Find("CountText").GetComponent<Text>();
        
        mBtnAdd.onClick.AddListener(() =>
        {
            mCount++;
            UpdateView();
        });
        
        mBtnSub.onClick.AddListener(() =>
        {
            mCount--;
            UpdateView();
        });
        
        UpdateView();
    }

    private void UpdateView()
    {
        mCountText.text = mCount.ToString();
    }
    
}
