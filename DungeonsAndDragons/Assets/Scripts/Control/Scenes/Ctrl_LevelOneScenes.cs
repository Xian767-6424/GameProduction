﻿/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: level one scene game manager
 *      
 * Description:
 *      1: spawn random Enemies with random position
 *      2: ect;
 *         
 * Date:2020
 * 
 * Verstion: 0.1
 * 
 * Modify Recoder;
 *  
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Global;
using Kernal;


namespace Control
{
    public class Ctrl_LevelOneScenes : BaseControl
    {
        public AudioClip Acbackground;              //background audioclip

        public Transform[] TraSpawnEnemyPosition_1; // enemy spawn position

        // Start is called before the first frame update
        void Start()
        {
            //background music
            AudioManager.SetAudioBackgroundVolumns(0.3f);
            AudioManager.SetAudioEffectVolumns(1f);
            AudioManager.PlayBackground(Acbackground);


            StartCoroutine(SpwanEnemy(10));
        }

        /// <summary>
        /// spawn enemys
        /// </summary>
        /// <param name="createEnemies">enemy amounts</param>
        /// <returns></returns>
        IEnumerator SpwanEnemy(int createEnemies)
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
            for (int i = 1; i <= createEnemies; ++i)
            {
               
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
                int randomNumber = UnityHelper.GetInstance().GetRandomNum(0, 7);
                //load enemy
                GameObject goEnemyClone = ResourceMgr.GetInstance().LoadAsset(GetRandomEnemyType(), true, TraSpawnEnemyPosition_1[randomNumber]);

            }
        }
         
        public string GetRandomEnemyType()
        {
            string strEnemyTypePath = "Prefabs/Enemy/skeleton_warrior_green";

            int intRandomNum = UnityHelper.GetInstance().GetRandomNum(1, 2);

            if(intRandomNum == 1)
            {
                strEnemyTypePath = "Prefabs/Enemy/skeleton_warrior_green";
            }
            else
            {
                strEnemyTypePath = "Prefabs/Enemy/skeleton_warrior_red";
            }

            return strEnemyTypePath;
        }
       
    }
}