using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

[Serializable]
public class ColorEvent : UnityEvent<Color> { }

public class ColorPicker : MonoBehaviour
{
    public SettingsView settingsView;
    public GameObject FadeScreen;
    public ColorEvent OnColorPreview;
    public ColorEvent OnColorSelect;
    RectTransform Rect;

    Texture2D ColorTexture;

    public Color colorSelected;

    private void OnEnable()
    {
        //OnColorPreview(settingsView.buttonClicked.GetComponent<Image>().color);
       // FadeScreen.SetActive(true);
    }
    private void OnDisable() {
        //FadeScreen.SetActive(false);
    }

    void Start()
    {
        Rect = GetComponent<RectTransform>();

        ColorTexture = GetComponent<Image>().mainTexture as Texture2D;
    }

    void Update()
    {
        //RaycastHit ray;
        //if(Physics.Raycast())
        if(RectTransformUtility.RectangleContainsScreenPoint(Rect, Input.mousePosition))
        {
            Vector2 delta;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta);

            float width = Rect.rect.width;
            float height = Rect.rect.height;

            delta += new Vector2(width * 0.5f, height * 0.5f);
            float x = Mathf.Clamp(delta.x / width, 0f, 1f);
            float y = Mathf.Clamp(delta.y / width, 0f, 1f);

            int texX = Mathf.RoundToInt(x * ColorTexture.width);
            int texY = Mathf.RoundToInt(y * ColorTexture.height);

            Color color = ColorTexture.GetPixel(texX, texY);

            //OnColorPreview?.Invoke(color);
            colorSelected = color;
            ColorButton();

            if(Input.GetMouseButtonDown(0))
            {
                //OnColorSelect?.Invoke(color);
                colorSelected = color;
                ColorButton();
            }
        }
    }

    public void ColorButton()
    {
        settingsView.buttonClicked.transform.GetChild(0).GetComponent<Image>().color = colorSelected;
    }

    /*public void ShowHideColorPicker(byte size)
    {
        Rect.rect.sizeDelta = new Vector2(size, size);
    }*/
}