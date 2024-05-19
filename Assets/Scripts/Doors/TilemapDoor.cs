using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapDoor : MonoBehaviour
{
    private bool isPlayerNearby = false;
    private bool isOpen = false;
    private Tilemap tilemap;
    private BoxCollider2D boxCollider;
    private BoundsInt doorBounds;
    private TileBase[] doorTiles;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        boxCollider = GetComponent<BoxCollider2D>();

        doorBounds = new BoundsInt(new Vector3Int(-1, -1, 0), new Vector3Int(3, 3, 1));

        doorTiles = tilemap.GetTilesBlock(doorBounds);

    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
        }
    }

    void ToggleDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            SetDoorActive(false);
            boxCollider.enabled = false;
            Invoke("CloseDoor", 2f);
        }
    }

    void CloseDoor()
    {
        isOpen = false;
        SetDoorActive(true);
        boxCollider.enabled = true;
    }

    void SetDoorActive(bool active)
    {
        if (active)
        {
            tilemap.SetTilesBlock(doorBounds, doorTiles);
            tilemap.GetComponent<TilemapRenderer>().enabled = true;
        }
        else
        {
            tilemap.GetComponent<TilemapRenderer>().enabled = false;
        }
    }   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
