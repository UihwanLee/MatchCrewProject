using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GalleryManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject galleryPanel;       //갤러리 패널
    public GameObject detailPanel;        //Explain 패널

    [Header("Gallery")]
    public Transform gridParent;          // 사진 배열에 붙는거
    public GameObject thumbnailPrefab;    // 썸네일 버튼 프리팹
    public List<Sprite> photos;           // 사진 목록
    public List<string> descriptions;     // 사진 설명
    public int itemsPerPage = 6;          // 3x2 구조 = 6개
    private int currentPage = 0;

    [Header("Detail View")]
    public Image detailImage;
    public Text detailText;

    void Start()
    {
        ShowPage(0); // 첫 페이지 보여주기
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
            int photoIndex = startIndex + i;
            if (photoIndex >= photos.Count) break;

            GameObject thumb = Instantiate(thumbnailPrefab, gridParent);
            thumb.GetComponent<Image>().sprite = photos[photoIndex];

            int index = photoIndex; // 캡처용 지역 변수
            thumb.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShowDetail(index);
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
