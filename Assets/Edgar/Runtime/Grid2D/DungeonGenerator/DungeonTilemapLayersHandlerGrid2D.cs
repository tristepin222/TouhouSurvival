using UnityEngine;
using UnityEngine.Tilemaps;

namespace Edgar.Unity
{
    public class DungeonTilemapLayersHandlerGrid2D : ITilemapLayersHandlerGrid2D
    {
        /// <summary>
        ///  Initializes individual tilemap layers.
        /// </summary>
        /// <param name="gameObject"></param>
        public void InitializeTilemaps(GameObject gameObject)
        {
            var grid = gameObject.AddComponent<Grid>();
            grid.cellSize = new Vector3(0.16f, 0.16f, 1);

            var floorTilemapObject = CreateTilemapGameObject("Floor", gameObject, 0, "Floor");

            var wallsTilemapObject = CreateTilemapGameObject("Walls", gameObject, 1, "Wall");
            AddCompositeCollider(wallsTilemapObject);

            var collideableTilemapObject = CreateTilemapGameObject("Collideable", gameObject, 2, "Wall");
            AddCompositeCollider(collideableTilemapObject);

            var other1TilemapObject = CreateTilemapGameObject("Other 1", gameObject, 3, "Floor");

            var other2TilemapObject = CreateTilemapGameObject("Other 2", gameObject, 2, "Floor");

            var other3TilemapObject = CreateTilemapGameObject("Other 3", gameObject, 5, "Floor");

            var roofTilemapObject = CreateTilemapGameObject("Roof", gameObject, 1, "Roof");
            var roof2TilemapObject = CreateTilemapGameObject("Roof 2", gameObject, 0, "Roof");
        }

        protected GameObject CreateTilemapGameObject(string name, GameObject parentObject, int sortingOrder, string LayerName)
        {
            var tilemapObject = new GameObject(name);
            tilemapObject.transform.SetParent(parentObject.transform);
            var tilemap = tilemapObject.AddComponent<Tilemap>();
            var tilemapRenderer = tilemapObject.AddComponent<TilemapRenderer>();
            tilemapRenderer.sortingOrder = sortingOrder;
            tilemapRenderer.sortingLayerName = LayerName;

            return tilemapObject;
        }

        protected void AddCompositeCollider(GameObject gameObject)
        {
            var tilemapCollider2D = gameObject.AddComponent<TilemapCollider2D>();
            tilemapCollider2D.usedByComposite = true;

            gameObject.AddComponent<CompositeCollider2D>();
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}