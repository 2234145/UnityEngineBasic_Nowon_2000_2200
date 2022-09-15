using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerHandler : MonoBehaviour, IPointerClickHandler
{
    public static TowerHandler instance;

    public bool isSelected =>_ghostTower;
    private GameObject _ghostTower;
    private TowerInfo _selectedTowerInfo;
    private Camera _camera;
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] private LayerMask _nodeLayer;
    public void SetTower(TowerInfo towerInfo)
    {
        _selectedTowerInfo = towerInfo;
        gameObject.SetActive(true);

        if (_ghostTower != null)
            Destroy(_ghostTower);

        if (TowerAssets.instance.TryGetGhostTower(_selectedTowerInfo.name, out GameObject ghostTowerPrefab))
        {
            _ghostTower = Instantiate(ghostTowerPrefab);
        }
        else
        {
            throw new System.Exception("고스트 타워 참조 실패");
        }

    }


    public void Clear()
    {
        if (_ghostTower != null)
            Destroy(_ghostTower);

        _ghostTower = null;
        _selectedTowerInfo=null;
        gameObject.SetActive(false);
    }

    public void SetGhostTowerPosition(Vector3 targetPos)
    {
        _ghostTower.transform.position = targetPos;
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;


        _camera = Camera.main;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_ghostTower == null)
            return;

        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hit, Mathf. Infinity, _nodeLayer ))
        {
          SetGhostTowerPosition ( _hit.collider.transform.position + Vector3.up *0.5f);
            _ghostTower.SetActive(true);
        }
        else
        {
            _ghostTower.SetActive(false);
        }

         if (Input.GetKey(KeyCode.Escape))
            Clear();

        transform.position = Input.mousePosition;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_hit.collider == null)
            return;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            buildTower();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Clear();
        }

    }

    private void buildTower()
    {
        if (_selectedTowerInfo.buildPrice > Player.instance.money)
        {
            Debug.Log($"잔액이 부족합니다");
            return;
        }


        if (_hit.collider.GetComponent<Node>().TryBuildTowerHere(_selectedTowerInfo.name, _hit.collider.GetComponent<Node>().GetUp()))
        {
            Debug.Log($"타워 건설 완료{_selectedTowerInfo.name}");
            Player.instance.money -= _selectedTowerInfo.buildPrice; //돈 차감
        }
    }
}
