/*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
| FyWorld - A top down simulation game in a fantasy medieval world.    |
|                                                                      |
|    :copyright: © 2019 Florian Gasquez.                               |
|    :license: GPLv3, see LICENSE for more details.                    |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
using UnityEngine;
using System;
using Fy.Definitions;
using Fy.World;
using Fy.Entities;
using System.Collections.Generic;
using Fy.Helpers;

namespace Fy.Characters.AI
{
    public class N_Attack : BrainNode
    {
            public override Task GetTask()
            {

                List<BaseCharacter> zombies = new List<BaseCharacter>();
                foreach (BaseCharacter c in Loki.map.zombies)
                {
                    float d = Utils.Distance(c.position, character.position);
                    if (d < 20)
                    {
                        zombies.Add(c);
                    }
                }
                if(zombies.Count > 0)
                {
                    BaseCharacter zombie = WorldUtils.NextToAttack(this.character.position, zombies);
                    if (zombie != null)
                    {
                        return new Task(
                            Defs.tasks["task_attack"],
                            new TargetList(new Target(zombie, 5))
                        );
                    } 
                }
                return null;
            }
        }
}