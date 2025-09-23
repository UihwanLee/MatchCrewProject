using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GalleryManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject galleryPanel;       //������ �г�
    public GameObject detailPanel;        //Explain �г�

    [Header("Gallery")]
    public Transform gridParent;          // ���� �迭�� �ٴ°�
    public GameObject thumbnailPrefab;    // ����� ��ư ������
    public List<Sprite> photos;           // ���� ���
    public List<string> descriptions;     // ���� ����
    public int itemsPerPage = 6;          // 3x2 ���� = 6��
    private int currentPage = 0;

    [Header("Detail View")]
    public Image detailImage;
    public Text detailText;

    void Start()
    {
        ShowPage(0); // ù ������ �����ֱ�
    }

    public void ShowPage(int page)
    {
        // ���� ����� �����
        foreach (Transform child in gridParent)
            Destroy(child.gameObject);

        currentPage = page;
        int startIndex = page * itemsPerPage;

        // �� ����� ����
        for (int i = 0; i < itemsPerPage; i++)
        {
            int photoIndex = startIndex + i;
            if (photoIndex >= photos.Count) break;

            GameObject thumb = Instantiate(thumbnailPrefab, gridParent);
            thumb.GetComponent<Image>().sprite = photos[photoIndex];

            int index = photoIndex; // ĸó�� ���� ����
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
