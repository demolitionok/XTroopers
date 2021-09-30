using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDamageVisualization : MonoBehaviour
{
    public static UIDamageVisualization Instance { get; private set; } 
    
    private class ActiveText
    {
        public TextMeshProUGUI uiText;
        public float UiMaxTime;
        public float UiTimer;
        public Vector3 unitPosition;

        public void MoveText(Camera camera)
        {
            float delta = 1.0f - (UiTimer / UiMaxTime);
            Vector3 pos = unitPosition + new Vector3(delta, delta, 0);
            pos = camera.WorldToScreenPoint(pos);
            pos.z = 0f;
            uiText.transform.position = pos;
        }
    }
    
    public TextMeshProUGUI textPrefab;
    List<ActiveText> activeTexts = new List<ActiveText>();
    private Camera mCamera;
    private Transform mTransform;
    private const int PoolSize = 64;
    Queue<TextMeshProUGUI> textPool = new Queue<TextMeshProUGUI>();
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        mCamera = Camera.main;
        mTransform = transform;

        for (int i = 0; i < PoolSize; i++)
        {
            TextMeshProUGUI temp = Instantiate(textPrefab, mTransform);
            temp.gameObject.SetActive(false);
            textPool.Enqueue(temp);
        }
    }

    private void Update()
    {
        for (int i = 0; i < activeTexts.Count; i++)
        {
            ActiveText at = activeTexts[i];
            at.UiTimer -= Time.deltaTime;
            if (at.UiTimer <= 0.0f)
            {
                at.uiText.gameObject.SetActive(false);
                textPool.Enqueue(at.uiText);
                activeTexts.RemoveAt(i);
                --i;
            }
            else
            {
                var color = at.uiText.color;
                color.a = at.UiTimer / at.UiMaxTime;
                at.uiText.color = color;
                at.MoveText(mCamera);
            }
        }
    }

    public void AddText(int amount, Vector3 unitPos)
    {
        var t = textPool.Dequeue();
        t.text = amount.ToString();
        t.gameObject.SetActive(true);
        ActiveText at = new ActiveText() {UiMaxTime = 1.0f};
        at.UiTimer = at.UiMaxTime;
        at.uiText = t;
        at.unitPosition = unitPos + Vector3.up;
        at.MoveText(mCamera);
        activeTexts.Add(at);
    }
}
