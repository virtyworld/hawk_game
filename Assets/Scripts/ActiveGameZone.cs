using System;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGameZone : MonoBehaviour
{
    
    private int screenSizeWidth;
    private int screenSizeHeight;
    private Chunk[] chunks;
    private Action OnNextChunkAction;
    private Chunk cnank;
    private List<Vector3> characterListPosition = new List<Vector3>();
   
    private int currentChunk;
    public void Setup(Chunk[] chunks,Character character)
    {
        this.chunks = chunks;
    }
    void Start()
    {
        OnNextChunkAction += GoToNextChunk;
        GetScreenSize();
    }

    //TODO: del fixed update
    private void FixedUpdate()
    {
        GetScreenSize();
        MoveCamera();
    }

    private void GetScreenSize()
    {
        //TODO: del if
        if (screenSizeWidth != UnityEngine.Screen.width || screenSizeHeight!= UnityEngine.Screen.height)
        {
            float aspect = (float)UnityEngine.Screen.width / UnityEngine.Screen.height;
            float orthographicSize = Camera.main.orthographicSize * 2.0f;
            float width = orthographicSize * aspect/10;
            float height = orthographicSize * aspect/10;
            transform.localScale = new Vector3(width, height, 1);
            screenSizeWidth = UnityEngine.Screen.width;
            screenSizeHeight = UnityEngine.Screen.height;
        }
    }

    private void MoveCamera()
    {
        Debug.Log("currentChunk "+currentChunk);
        if (currentChunk > 0)
        {
            if (transform.position != characterListPosition[currentChunk] )
            {
                Vector3 pos = new Vector3(characterListPosition[currentChunk].x,-characterListPosition[currentChunk].y,0);
                transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 1);
            }  
        }
    }
    private void GoToNextChunk()
    {
        if (IsThisLastChunk())
        {
            //show gamescreen
        }
        else
        {
            //TODO:move character
            //character.transform.position += new Vector3(characterListPosition[currentChunk].x,characterListPosition[currentChunk].y,0);
        }  
        currentChunk += 1;
    }

    private bool IsThisLastChunk()
    {
        
        return false;
    }
    
    public void SpawnChunk()
    {
        //TODO:spawn chunk
        float orthographicSize = Camera.main.orthographicSize * 2.0f;
          
        for (int i = 0; i < chunks.Length; i++)
        {
            Chunk chunk = Instantiate(chunks[i], transform);
            chunk.Setup(OnNextChunkAction);
            chunk.transform.position = new Vector3(0, orthographicSize * i, 0);
            characterListPosition.Add(chunk.transform.position);
            Debug.Log("chunk.transform.position "+chunk.transform.position);
        }
          
    }
}
