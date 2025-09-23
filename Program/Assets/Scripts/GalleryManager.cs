using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GalleryManager : MonoBehaviour
{
    public GameObject galleryPanel;         //갤러리 선언
    public GameObject detailPanel;         // 추가 설명창 선언

    public Transform gridParent;           // GridLayoutGroup
    public GameObject thumbnailPrefab;    // 썸네일 버튼
    public List<Sprite> photos;            // 사진 목록, 이미지 sprite
    public List<string> descriptions;     // 사진 설명, 문자이기 때문에 string으로

    private int currentPage = 0;        //시작 페이지 0으로 설정 (아마 그래봤자 1장 2장 정도만 늘어날 것.
    private int itemsPerPage = 6;         // 한 면에 6장, 2*3

    public Image detailImage;           //확대 이미지 선언
    public Text detailText;         //확대 이미지 설명 선언

    void Start()
    {
        ShowPage(0);                // 시작하면 냅다 여러장 보여줌
    }

    public void ShowPage(int page)          //int page가 현재 보여주는 page 인데 많아봤자 3장이 될 것
    {
        foreach (Transform child in gridParent) // 기존 썸네일 지우기, 썸네일 없는 상태로 초기화
            Destroy(child.gameObject);          //파괴

        currentPage = page;                           //현재 페이지
        int startIndex = page * itemsPerPage;           //각 페이지마자 사진

        for (int i = 0; i < itemsPerPage; i++)          //이번 페이지에 이미지 생성 , 위에서 다 파괴했으니까, 최대 갯수까지 생성
        {
            int idx = startIndex + i;                   //실제로 사용하는 사진들
            if (idx >= photos.Count) break;             //더 이상 사진 없으면 탈출

            GameObject thumb = Instantiate(thumbnailPrefab, gridParent);        //반복해서 만들기, 강의4인가에 나오는 내용
            thumb.GetComponent<Image>().sprite = photos[idx];               //이미지 요소 겟하기

            int captured = idx;                                 // 원본 가져오면 충돌날 수 있으니 복사해서 가져옴
            thumb.GetComponent<Button>().onClick.AddListener(() =>      //버튼 누르면 아래 캡쳐 한거 보여줌
            {
                ShowDetail(captured);               //캡쳐한거 보여주기
            });
        }
    }

    public void NextPage()                  //다음 페이지로 넘어가기
    {
        if ((currentPage + 1) * itemsPerPage < photos.Count)        //다음 페이지인지 아닌지 확인하기 위한 것.(사진이 있어야 다음 페이지)
            ShowPage(currentPage + 1);
    }

    public void PrevPage()                                      //이전 페이지로 이동, 마찬가지로 확인, 
    {
        if (currentPage > 0)
            ShowPage(currentPage - 1);
    }

    public void ShowDetail(int index)                                   //저 위에서 말한 showdetail함수, 즉 사진 확대
    {
        galleryPanel.SetActive(false);                                  //누르면 false인 애가 true가 댐. 체크박스에 체크 안한게 체크가 되는 것.
        detailPanel.SetActive(true);

        detailImage.sprite = photos[index];                     //해당 사진 ㄷㄷㄷㅈ
        detailText.text = descriptions[index];                  //해당 설명 ㄷㄷㄷㅈ
    }

    public void CloseDetail()                                   //닫기
    {
        detailPanel.SetActive(false);
        galleryPanel.SetActive(true);
    }
}
