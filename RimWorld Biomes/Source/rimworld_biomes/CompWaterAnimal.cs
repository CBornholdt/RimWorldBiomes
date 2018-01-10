﻿using System;
using UnityEngine;
using Verse;

namespace rimworld_biomes
{
    public class CompWaterAnimal : ThingComp
    {
        bool submerged = false;
        public override void CompTick()
        {
            if(Props.allowedTiles.Contains(parent.Position.GetTerrain(parent.Map))){
                if(!submerged){
                    ResolveSubmergedGraphic();
                    submerged = true;
                }
            }else{
                if(submerged){
                    ResolveBaseGraphic();
                    submerged = false;
                }
            }
            base.CompTick();
        }
        public CompProperties_WaterAnimal Props
        {
            get
            {
                return (CompProperties_WaterAnimal)this.props;
            }
        }

        public void ResolveSubmergedGraphic(){
            if (Props.submergedGraphic != null &&
    ((Pawn)parent).Drawer?.renderer?.graphics != null)
            {
                PawnGraphicSet pawnGraphicSet = ((Pawn)parent).Drawer?.renderer?.graphics;
                pawnGraphicSet = ((Pawn)parent).Drawer?.renderer?.graphics;
                pawnGraphicSet.ClearCache();
                pawnGraphicSet.nakedGraphic = Props.submergedGraphic.Graphic;
            }
        }

        public void ResolveBaseGraphic(){
            if (Props.submergedGraphic != null &&
    ((Pawn)parent).Drawer?.renderer?.graphics != null)
            {
                PawnGraphicSet pawnGraphicSet = ((Pawn)parent).Drawer?.renderer?.graphics;
                pawnGraphicSet.ClearCache();

                //Duplicated code from -> Verse.PawnGrapic -> ResolveAllGraphics
                var curKindLifeStage = ((Pawn)parent).ageTracker.CurKindLifeStage;
                if (((Pawn)parent).gender != Gender.Female || curKindLifeStage.femaleGraphicData == null)
                    pawnGraphicSet.nakedGraphic = curKindLifeStage.bodyGraphicData.Graphic;
                else
                    pawnGraphicSet.nakedGraphic = curKindLifeStage.femaleGraphicData.Graphic;
                pawnGraphicSet.rottingGraphic = pawnGraphicSet.nakedGraphic.GetColoredVersion(ShaderDatabase.CutoutSkin,
                    PawnGraphicSet.RottingColor, PawnGraphicSet.RottingColor);
                if (((Pawn)parent).RaceProps.packAnimal)
                    pawnGraphicSet.packGraphic = GraphicDatabase.Get<Graphic_Multi>(
                        pawnGraphicSet.nakedGraphic.path + "Pack", ShaderDatabase.Cutout,
                        pawnGraphicSet.nakedGraphic.drawSize, Color.white);
                if (curKindLifeStage.dessicatedBodyGraphicData != null)
                    pawnGraphicSet.dessicatedGraphic =
                                      curKindLifeStage.dessicatedBodyGraphicData.GraphicColoredFor(((Pawn)parent));
            }
        }
    }
}