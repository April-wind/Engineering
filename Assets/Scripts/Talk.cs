using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour {
    //定义NPC对话数据  
    private string[] mData ={"你好,我是NPC","这是一个Unity3D编写的脚本",
        "对话框是基于GUI实现的","博主是一个喜欢游戏的人","这是一个关于NPC对话的简单实现"
        ,"大家就不要笑话这个界面丑陋了啊"};
    //当前对话索引  
    private int index = 0;
    //用于显示对话的GUI Text  
    public Text mText;
    //对话标示贴图  
    public Texture mTalkIcon;
    //是否显示对话标示贴图  
    private bool isTalk = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //用ScreenToWorldPoint将Input.mousePosition转换成世界坐标，这样就可以用来与GameObject相比较了。

//接下来，我们用Physics2D.Raycast生成射线，提供一个Vector2类型的mousePos忽略Z轴作为起始点。还要提供一个Vector2.zero作为Raycast的方向以保证只有在点击方向的位置上的物体才可以被检测到：

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
       

        //现在可以用Raycast2D来确定是否有物体被点击了：

           if (hit.collider!=null ) {

            //如果击中了NPC  
        
                //进入对话状态  
                isTalk = true;
                //允许绘制  
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Debug.Log("下一句话");
                    //绘制指定索引的对话文本  
                    if (index < mData.Length)
                    {
                        mText.text = "NPC:" + mData[index];
                        index = index + 1;
                    }
                    else
                    {
                        index = 0;
                        mText.text = "NPC:" + mData[index];
                    }
                }
                if (Input.GetKeyDown(KeyCode.V))
                {
                    Debug.Log("一句话");
                }
               
           }
            
        }
        
    }
    

    void OnGUI()
    {
        if (isTalk)
        {
            ////禁用系统鼠标指针  
            //Screen.lockCursor = true;
            Rect mRect = new Rect(Input.mousePosition.x - mTalkIcon.width,
                Screen.height - Input.mousePosition.y - mTalkIcon.height, mTalkIcon.width, mTalkIcon.height);
            //绘制自定义鼠标指针  
            GUI.DrawTexture(mRect, mTalkIcon);
        }

    }

}


 