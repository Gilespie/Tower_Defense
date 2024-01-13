using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Tower _towerPrefab;
    [SerializeField] private bool _isPlaceable;
    public bool IsPlaceable { get { return _isPlaceable; } }
    private GridManager _gridManager;
    private Pathfindning _pathfinding;
    private Vector2Int _coordinates = new Vector2Int();

    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        _pathfinding = FindObjectOfType<Pathfindning>();
    }

    private void Start()
    {
        if(_gridManager != null)
        {
            _coordinates = _gridManager.GetCoordinatesFromPosition(transform.position);

            if(!_isPlaceable)
            {
                _gridManager.BlockNode(_coordinates);
            }
        }
    }

    private void OnMouseDown()
    {
        if(_gridManager.GetNode(_coordinates).isWalkable && !_pathfinding.WillBlockPath(_coordinates))
        {
            bool isSuccessful = _towerPrefab.CreateTower(_towerPrefab, transform.position);
            
            if(isSuccessful)
            {
                _gridManager.BlockNode(_coordinates);
                _pathfinding.NotifyReceivers();
            }
        }
    }
}