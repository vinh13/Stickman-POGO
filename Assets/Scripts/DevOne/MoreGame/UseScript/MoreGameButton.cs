using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoreGameButton : MonoBehaviour
{

    [SerializeField]
    private Button mainButton;
    [SerializeField]
    private Text gameNameText;
    [SerializeField]
    private Image iconImage;

    private MoreGameItem currentItem;

    public void Awake()
    {
        mainButton.onClick.AddListener(OnMainButtonClicked);

        CheckAndLoadMoreGame();

        MoreGameController.OnMoreGameItemLoaded += MoreGameController_OnMoreGameItemLoaded;
    }

    private void CheckAndLoadMoreGame()
    {
        var items = MoreGameController.Instance.GetItems();

        if (items.Count > 0)
        {
            this.transform.localScale = Vector3.one;
            var randomItem = items.PickARandom<MoreGameItem>();
            ShowMoreGame(randomItem);
        }
        else
        {
            this.transform.localScale = Vector3.zero;
        }
    }

    private void MoreGameController_OnMoreGameItemLoaded()
    {
        CheckAndLoadMoreGame();
    }

    private void OnMainButtonClicked()
    {
        if (currentItem != null)
        {
            Application.OpenURL(currentItem.gameUrl);
        }
    }

    private void ShowMoreGame(MoreGameItem item)
    {
        currentItem = item;
        gameNameText.text = item.gameName;

        StartCoroutine(LoadIcon(item.iconGameUrl));
    }

    private IEnumerator LoadIcon(string iconPath)
    {
        WWW w = new WWW(iconPath);

        yield return w;

        if (w.isDone && w.error == null)
        {
            Sprite sprite = Sprite.Create(w.texture, new Rect(0, 0, w.texture.width, w.texture.height), new Vector2(0, 0));
            iconImage.sprite = sprite;
        }
    }

    private void OnDestroy()
    {
        MoreGameController.OnMoreGameItemLoaded -= MoreGameController_OnMoreGameItemLoaded;
    }
}
