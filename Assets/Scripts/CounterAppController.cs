using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MyCounterApp
{
    public class CounterAppModel : AbstractModel
    {
        public int Count;
        protected override void OnInit()
        {
            Count = 0;
        }
    }

    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            this.RegisterModel(new CounterAppModel());
        }
    }
    
    public class CounterAppController : MonoBehaviour, IController
    {
        // View
        private Button mBtnAdd;
        private Button mBtnSub;
        private Text mCountText;
        
        // Model
        private CounterAppModel mModel;
        
        void Start()
        {
            mModel = this.GetModel<CounterAppModel>();
            // Get UI components
            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
            mCountText = transform.Find("CountText").GetComponent<Text>();
            
            mBtnAdd.onClick.AddListener(() =>
            {
                mModel.Count++;
                UpdateView();
            });
            
            mBtnSub.onClick.AddListener(() =>
            {
                mModel.Count--;
                UpdateView();
            });
            
            UpdateView();
        }

        private void UpdateView()
        {
            mCountText.text = mModel.Count.ToString();
        }

        public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }

        private void OnDestroy()
        {
            mModel = null;
        }
        
    }
}