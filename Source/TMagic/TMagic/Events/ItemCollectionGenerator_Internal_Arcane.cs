﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;
using RimWorld;

namespace TorannMagic
{
    public class ItemCollectionGenerator_Internal_Arcane
    {
        private const float GemstoneChance = 0.03f;
        private const float LuciferiumChance = 0.2f;
        private const float ArcaneScriptChance = 0.06f;
        private const float DrugChance = 0.15f;
        private const float SpellChance = 0.2f;
        private const float SkillChance = 0.2f;
        private const float MasterSpellChance = 0.1f;

        private static readonly IntRange GemstoneCountRange = new IntRange(1, 2);
        private static readonly IntRange LuciferiumCountRange = new IntRange(8, 12);
        private static readonly IntRange RawMagicyteRange = new IntRange(40, 100);
        private static readonly IntRange ManaPotionRange = new IntRange(1, 4);
        private static readonly IntRange DrugCountRange = new IntRange(3, 10);
        private static readonly IntRange SpellCountRange = new IntRange(1, 2);
        private static readonly IntRange SkillCountRange = new IntRange(1, 2);

        private float collectiveMarketValue = 0;

        public List<Thing> Generate(int totalMarketValue, List<Thing> outThings)
        {
            
            for (int j = 0; j < 10; j++)
            {
                //Torn Scripts
                if (Rand.Chance(0.3f) && (totalMarketValue - collectiveMarketValue) > TorannMagicDefOf.Torn_BookOfArcanist.BaseMarketValue *.8f)
                {
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfInnerFire, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfHeartOfFrost, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfStormBorn, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfArcanist, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfValiant, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfSummoner, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfNature, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfUndead, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfPriest, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfBard, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfDemons, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfEarth, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfMagitech, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfHemomancy, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    if (Rand.Chance(ArcaneScriptChance))
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.Torn_BookOfEnchanter, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }

                }
                //Arcane Scripts
                if (Rand.Chance(ArcaneScriptChance) && (totalMarketValue - collectiveMarketValue) > TorannMagicDefOf.BookOfArcanist.BaseMarketValue *.8f)
                {
                    float rnd = Rand.Range(0f, 1f);
                    float scriptCount = 22f;
                    if (rnd < 1f/scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfInnerFire, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 2f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfHeartOfFrost, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 3f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfStormBorn, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 4f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfArcanist, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 5f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfValiant, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 6f / scriptCount)
                        {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfSummoner, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 7f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfNecromancer, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 8f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfDruid, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 9f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfPriest, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 10f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfBard, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 11f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfDemons, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 12f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfEarth, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 13f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfGladiator, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 14f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfSniper, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 15f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfBladedancer, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 16f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfRanger, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 17f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfFaceless, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 18f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfMagitech, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 19f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfDeathKnight, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 20f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfHemomancy, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else if (rnd < 21f / scriptCount)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfEnchanter, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }
                    else 
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.BookOfPsionic, null);
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue;
                    }

                }
                //Mana Potions
                if (Rand.Chance(0.2f) && (totalMarketValue - collectiveMarketValue) > TorannMagicDefOf.ManaPotion.BaseMarketValue * ManaPotionRange.RandomInRange)
                {
                    int randomInRange = ManaPotionRange.RandomInRange;
                    for (int i = 0; i < randomInRange; i++)
                    {
                        Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.ManaPotion, null);
                        thing.stackCount = ManaPotionRange.RandomInRange;
                        outThings.Add(thing);
                        collectiveMarketValue += thing.MarketValue * thing.stackCount;
                    }
                }
                //Gemstones
                if (Rand.Chance(GemstoneChance) && (totalMarketValue - collectiveMarketValue) > 1000f)
                {
                    int randomInRange = GemstoneCountRange.RandomInRange;
                    for (int i = 0; i < randomInRange; i++)
                    {
                        List<Thing> gemstoneZero = new List<Thing>();
                        Thing item = null;
                        ItemCollectionGenerator_Gemstones icg_g = new ItemCollectionGenerator_Gemstones();
                        icg_g.Generate(1000, gemstoneZero);
                        item = gemstoneZero[0];
                        if (item != null)
                        {
                            outThings.Add(item);
                            collectiveMarketValue += item.MarketValue;
                        }
                    }
                }
                //Syrrium
                if (Rand.Chance(LuciferiumChance) && (totalMarketValue - collectiveMarketValue) > TorannMagicDefOf.TM_Syrrium.BaseMarketValue * LuciferiumCountRange.RandomInRange)
                {
                    Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.TM_Syrrium, null);
                    thing.stackCount = LuciferiumCountRange.RandomInRange;
                    outThings.Add(thing);
                    collectiveMarketValue += thing.MarketValue * thing.stackCount;
                }
                //Raw Magicyte
                if (Rand.Chance(DrugChance))
                {

                    Thing thing = ThingMaker.MakeThing(TorannMagicDefOf.RawMagicyte, null);
                    thing.stackCount = RawMagicyteRange.RandomInRange;
                    outThings.Add(thing);
                    collectiveMarketValue += thing.MarketValue * thing.stackCount;

                }
                //Master Spells
                if (Rand.Chance(MasterSpellChance) && (totalMarketValue - collectiveMarketValue) > TorannMagicDefOf.SpellOf_Blizzard.BaseMarketValue)
                {
                    Thing thing;
                    float rnd = Rand.Range(0f, 30f);
                    if (rnd > 28)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_PsychicShock, null);
                    }
                    else if (rnd > 26 && rnd <= 28)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Shapeshift, null);
                    }
                    else if (rnd > 24 && rnd <= 26)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_BloodMoon, null);
                    }
                    else if (rnd > 22 && rnd <= 24)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_OrbitalStrike, null);
                    }
                    else if (rnd > 20 && rnd <= 22)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Meteor, null);
                    }
                    else if (rnd > 18 && rnd <= 20)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Scorn, null);
                    }
                    else if (rnd > 16 && rnd <= 18)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_BattleHymn, null);
                    }
                    else if (rnd > 14 && rnd <= 16)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_BattleHymn, null);
                    }
                    else if (rnd > 12 && rnd <= 14)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_HolyWrath, null);
                    }
                    else if (rnd > 10 && rnd <= 12)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_LichForm, null);
                    }
                    else if (rnd > 8 && rnd <= 10)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Blizzard, null);
                    }
                    else if (rnd > 6 && rnd <= 8)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Firestorm, null);
                    }
                    else if (rnd > 4 && rnd <= 6)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_FoldReality, null);
                    }
                    else if (rnd > 2 && rnd <= 4)
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Resurrection, null);
                    }
                    else
                    {
                        thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_RegrowLimb, null);
                    }
                    outThings.Add(thing);
                    collectiveMarketValue += thing.MarketValue;
                }
                //Spells
                if (Rand.Chance(SpellChance) && (totalMarketValue - collectiveMarketValue) > 1000f)
                {
                    int randomInRange = SpellCountRange.RandomInRange;
                    Thing thing = new Thing();
                    for (int i = 0; i < randomInRange; i++)
                    {
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Blink, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Teleport, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Heal, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Rain, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Heater, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Cooler, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_DryGround, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_WetGround, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_ChargeBattery, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_SmokeCloud, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_EMP, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Extinguish, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_SummonMinion, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_TransferMana, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_SiphonMana, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_ManaShield, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_PowerNode, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Sunlight, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_SpellMending, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_CauterizeWound, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_FertileLands, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_TechnoShield, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Sabotage, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10f) > 9f)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SpellOf_Overdrive, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                    }
                }
                //Skills
                if (Rand.Chance(SpellChance) && (totalMarketValue - collectiveMarketValue) > 800f)
                {
                    int randomInRange = SkillCountRange.RandomInRange;
                    Thing thing = new Thing();
                    for (int i = 0; i < randomInRange; i++)
                    {
                        if (Rand.Range(0, 10) > 9)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SkillOf_Sprint, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10) > 9)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SkillOf_GearRepair, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10) > 9)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SkillOf_InnerHealing, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10) > 9)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SkillOf_HeavyBlow, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10) > 9)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SkillOf_StrongBack, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10) > 9)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SkillOf_ThickSkin, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }
                        if (Rand.Range(0, 10) > 9)
                        {
                            thing = ThingMaker.MakeThing(TorannMagicDefOf.SkillOf_FightersFocus, null);
                            outThings.Add(thing);
                            collectiveMarketValue += thing.MarketValue;
                        }                        
                    }
                }
            }
            return outThings;
        }
    }
}
