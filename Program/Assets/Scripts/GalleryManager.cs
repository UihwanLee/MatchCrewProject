using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GalleryManager : MonoBehaviour
{
    public GameObject galleryPanel;
    public GameObject detailPanel;

    public Transform gridParent;          // GridLayoutGroup
    public GameObject thumbnailPrefab;    // ����� ��ư
    public List<Sprite> photos;           // ���� ���
    public List<string> descriptions;     // ���� ����

    private int currentPage = 0;
    private int itemsPerPage = 6;         // 2�� x 3�� = 6��

    public Image detailImage;
    public Text detailText;

    void Start()
    {
        ShowPage(0);  // �����ϸ� ù ������ ������
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
            int idx = startIndex + i;
            if (idx >= photos.Count) break;

            GameObject thumb = Instantiate(thumbnailPrefab, gridParent);
            thumb.GetComponent<Image>().sprite = photos[idx];

            int captured = idx; // Ŭ�� �� ������ �ε���
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
