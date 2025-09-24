using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GalleryManager : MonoBehaviour
{
    public GameObject galleryPanel;         //������ ����
    public GameObject detailPanel;         // �߰� ����â ����

    public Transform gridParent;           // GridLayoutGroup
    public GameObject thumbnailPrefab;    // ����� ��ư
    public List<Sprite> photos;            // ���� ���, �̹��� sprite
    public List<string> descriptions;     // ���� ����, �����̱� ������ string����

    private int currentPage = 0;        //���� ������ 0���� ���� (�Ƹ� �׷����� 1�� 2�� ������ �þ ��.
    private int itemsPerPage = 6;         // �� �鿡 6��, 2*3

    public Image detailImage;           //Ȯ�� �̹��� ����
    public Text detailText;         //Ȯ�� �̹��� ���� ����

    void Start()
    {
        ShowPage(0);                // �����ϸ� ���� ������ ������
    }

    public void ShowPage(int page)          //int page�� ���� �����ִ� page �ε� ���ƺ��� 3���� �� ��
    {
        foreach (Transform child in gridParent) // ���� ����� �����, ����� ���� ���·� �ʱ�ȭ
            Destroy(child.gameObject);          //�ı�

        currentPage = page;                           //���� ������
        int startIndex = page * itemsPerPage;           //�� ���������� ����

        for (int i = 0; i < itemsPerPage; i++)          //�̹� �������� �̹��� ���� , ������ �� �ı������ϱ�, �ִ� �������� ����
        {
            int idx = startIndex + i;                   //������ ����ϴ� ������
            if (idx >= photos.Count) break;             //�� �̻� ���� ������ Ż��

            GameObject thumb = Instantiate(thumbnailPrefab, gridParent);        //�ݺ��ؼ� �����, ����4�ΰ��� ������ ����
            thumb.GetComponent<Image>().sprite = photos[idx];               //�̹��� ��� ���ϱ�

            int captured = idx;                                 // ���� �������� �浹�� �� ������ �����ؼ� ������
            thumb.GetComponent<Button>().onClick.AddListener(() =>      //��ư ������ �Ʒ� ĸ�� �Ѱ� ������
            {
                ShowDetail(captured);               //ĸ���Ѱ� �����ֱ�
            });
        }
    }

    public void NextPage()                  //���� �������� �Ѿ��
    {
        if ((currentPage + 1) * itemsPerPage < photos.Count)        //���� ���������� �ƴ��� Ȯ���ϱ� ���� ��.(������ �־�� ���� ������)
            ShowPage(currentPage + 1);
    }

    public void PrevPage()                                      //���� �������� �̵�, ���������� Ȯ��, 
    {
        if (currentPage > 0)
            ShowPage(currentPage - 1);
    }

    public void ShowDetail(int index)                                   //�� ������ ���� showdetail�Լ�, �� ���� Ȯ��
    {
        galleryPanel.SetActive(false);                                  //������ false�� �ְ� true�� ��. üũ�ڽ��� üũ ���Ѱ� üũ�� �Ǵ� ��.
        detailPanel.SetActive(true);

        detailImage.sprite = photos[index];                     //�ش� ���� ��������
        detailText.text = descriptions[index];                  //�ش� ���� ��������
    }

    public void CloseDetail()                                   //�ݱ�
    {
        detailPanel.SetActive(false);
        galleryPanel.SetActive(true);
    }
}
