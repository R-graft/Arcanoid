using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class LevelEditor : EditorWindow
{
    public GameObject testTile;

    public Transform editorBlocksParent;

    public BlocksData editorData;

    private SceneEditor _sceneEditor;

    private EditorGrid _editorGrid;

    public List<Block> currentObjects;

    public int index;

    private string _saveStatus;

    private string _levelNumber;

    private string _savePath;

    private bool _isEditing;

    [MenuItem("Editors/LevelEditor")]
    public static void Init()
    {
        LevelEditor levelEditor = GetWindow<LevelEditor>("LevelEditor");

        levelEditor.Show();
    }
    private void OnGUI()
    {
        if (_sceneEditor == null)
        {
            _sceneEditor = new SceneEditor();
        }

        if (editorData == null)
        {
            GUILayout.Label("EditorData");
            editorData = (BlocksData)EditorGUILayout.ObjectField(editorData, typeof(BlocksData), true);
        }

        if (testTile == null)
        {
            GUILayout.Label("TestTilePrefab");
            testTile = (GameObject)EditorGUILayout.ObjectField(testTile, typeof(GameObject), true);
        }

        else
        {
            EditorGUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("BLOCK TYPE", EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            EditorGUILayout.Space(10);

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("<"))
            {
                index--;
                if (index < 0)
                {
                    index = editorData.blocksTypes.Length - 1;
                }
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.Space(5);

            GUILayout.Label(editorData.blocksTypes[index].blockId.ToString(), EditorStyles.boldLabel);

            EditorGUILayout.Space(5);
            GUILayout.FlexibleSpace();

            if (GUILayout.Button(">"))
            {
                index++;
                if (index > editorData.blocksTypes.Length - 1)
                {
                    index = 0;
                }
            }

            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            GUI.color = _isEditing ? Color.yellow : Color.white;
            if (GUILayout.Button("CreateBlocks"))
            {
                _isEditing = !_isEditing;

                if (_isEditing)
                {
                    currentObjects = new List<Block>();

                    SceneView.duringSceneGui += _sceneEditor.OnsceneGui;

                    _sceneEditor.Init(this, editorBlocksParent);

                    if (_editorGrid == null)
                    {
                        _editorGrid = new EditorGrid(testTile);
                    }

                    _editorGrid.CreateGrid();
                }

                if (!_isEditing)
                {
                    SceneView.duringSceneGui -= _sceneEditor.OnsceneGui;

                    _editorGrid.ClearGrid();

                    foreach (var block in currentObjects)
                    {
                        DestroyImmediate(block.gameObject);
                    }

                    currentObjects.Clear();
                }
            }

            GUI.color = Color.white;

            GUILayout.Space(25);

            if (_isEditing)
            {
                if (GUILayout.Button("Undo"))
                {
                    if (currentObjects != null && currentObjects.Count != 0)
                    {
                        DestroyImmediate(currentObjects[currentObjects.Count - 1].gameObject, false);

                        currentObjects.RemoveAt(currentObjects.Count - 1);
                    }
                }

                GUILayout.Space(10);

                if (GUILayout.Button("Clear"))
                {
                    foreach (var block in currentObjects)
                    {
                        DestroyImmediate(block.gameObject);
                    }

                    currentObjects.Clear();
                }

                GUILayout.Space(50);


                if (GUILayout.Button("SaveLevel"))
                {
                    var newData = new LevelData();

                    newData.blockTags = new List<string>();

                    newData.blockIndexX = new List<int>();

                    newData.blockIndexY = new List<int>();

                    if (int.TryParse(_levelNumber, out int currentNumber))
                    {
                        newData.levelnumber = currentNumber;

                        foreach (var Block in currentObjects)
                        {
                            newData.blockTags.Add(Block.blockId.ToString());

                            var indexes = Block.name.Split(',');

                            newData.blockIndexX.Add(int.Parse(indexes[0]));

                            newData.blockIndexY.Add(int.Parse(indexes[1]));
                        }

                        var directory = Application.dataPath + $"/App/Resources/Data/Levels";

                        if (Directory.Exists(directory))
                        {
                            _savePath = Application.dataPath + $"/App/Resources/Data/Levels/{_levelNumber}.json";

                            string savingData = JsonUtility.ToJson(newData);

                            File.WriteAllText(_savePath, savingData);

                            _saveStatus = "Level Saved";
                        }
                        else
                        {
                            _saveStatus = "Save Path is incorrect";
                        }

                    }
                    else
                    {
                        GUILayout.Space(5);
                        _saveStatus = "Level name incorrect";
                    }
                }

                GUI.color = _saveStatus == "Level Saved" ? Color.green : Color.red;
                GUILayout.Label(_saveStatus, EditorStyles.boldLabel);

                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                GUILayout.Label("LevelNumber");
                _levelNumber = GUILayout.TextField(_levelNumber);
                GUILayout.EndHorizontal();
                GUI.color = Color.white;

                GUILayout.Space(20);


                if (GUILayout.Button("Load Level"))
                {
                    foreach (var block in currentObjects)
                    {
                        DestroyImmediate(block.gameObject);
                    }

                    currentObjects.Clear();


                    string levelData;

                    string dataPath = Application.dataPath + $"/App/Resources/Data/Levels/{_levelNumber}.json";

                    if (File.Exists(dataPath))
                    {
                        levelData = File.ReadAllText(dataPath);

                        LevelData loadedLevel = JsonUtility.FromJson<LevelData>(levelData);

                        var _indexes = _editorGrid;

                        for (int i = 0; i < loadedLevel.blockTags.Count; i++)
                        {
                            var obj = editorData.blocksTypes.First(o => o.blockId.ToString() == loadedLevel.blockTags[i]);

                            var newblock = Instantiate(obj);

                            var tilePosition = loadedLevel.blockIndexX[i].ToString() + "," + loadedLevel.blockIndexY[i].ToString();

                            GameObject tilePos = _editorGrid._testTiles.First(p => p.name == tilePosition);

                            newblock.name = tilePosition;

                            newblock.transform.position = tilePos.transform.position;

                            currentObjects.Add(newblock);
                        }
                    }
                    else
                    {
                        _saveStatus = "level Data incorrect";
                    }
                }
            }
        }
    }
}
