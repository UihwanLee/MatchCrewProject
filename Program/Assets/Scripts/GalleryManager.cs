using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GalleryManager : MonoBehaviour
{
    public GameObject galleryPanel;
    public GameObject detailPanel;

    public Transform gridParent;          // GridLayoutGroup
    public GameObject thumbnailPrefab;    // 썸네일 버튼
    public List<Sprite> photos;           // 사진 목록
    public List<string> descriptions;     // 사진 설명

    private int currentPage = 0;
    private int itemsPerPage = 6;         // 2열 x 3행 = 6장

    public Image detailImage;
    public Text detailText;

    void Start()
    {
        ShowPage(0);  // 시작하면 첫 페이지 보여줌
    }

    public void ShowPage(int page)
    {
        // 기존 썸네일 지우기
        foreach (Transform child in gridParent)
            Destroy(child.gameObject);

        currentPage = page;
        int startIndex = page * itemsPerPage;

        // 새 썸네일 생성
        for (int i = 0; i < itemsPerPage; i++)
        {
            int idx = startIndex + i;
            if (idx >= photos.Count) break;

            GameObject thumb = Instantiate(thumbnailPrefab, gridParent);
            thumb.GetComponent<Image>().sprite = photos[idx];

            int captured = idx; // 클릭 시 참조할 인덱스
            thumb.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShowDetail(captured);
            });
        }
    }

    public void NextPage()
    {
        if ((currentPage + 1) * itemsPerPage < photos.Count)
            ShowPage(currentPage + 1);
    }

    public void PrevPage()
    {
        if (currentPage > 0)
            ShowPage(currentPage - 1);
    }

    public void ShowDetail(int index)
    {
        galleryPanel.SetActive(false);
        detailPanel.SetActive(true);

        detailImage.sprite = photos[index];
        detailText.text = descriptions[index];
    }

    public void CloseDetail()
    {
        detailPanel.SetActive(false);
        galleryPanel.SetActive(true);
    }
}
