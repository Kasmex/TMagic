﻿using RimWorld;
using Verse;
using System.Collections.Generic;
using UnityEngine;


namespace TorannMagic
{
	public class CompUseEffect_LearnMagic : CompUseEffect
	{

		public override void DoEffect(Pawn user)
		{
            if (parent.def != null && user.story.traits.HasTrait(TorannMagicDefOf.Gifted))
            {
                Trait giftedTrait = new Trait();
                if (parent.def.defName == "BookOfInnerFire" || parent.def.defName == "Torn_BookOfInnerFire")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    user.story.traits.GainTrait(new Trait(TraitDef.Named("InnerFire"), 4, false));
                    if(parent.def.defName == "BookOfInnerFire")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfHeartOfFrost" || parent.def.defName == "Torn_BookOfHeartOfFrost")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    user.story.traits.GainTrait(new Trait(TraitDef.Named("HeartOfFrost"), 4, false));
                    if (parent.def.defName == "BookOfHeartOfFrost")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfStormBorn" || parent.def.defName == "Torn_BookOfStormBorn")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    user.story.traits.GainTrait(new Trait(TraitDef.Named("StormBorn"), 4, false));
                    if (parent.def.defName == "BookOfStormBorn")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfArcanist" || parent.def.defName == "Torn_BookOfArcanist")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Arcanist"), 4, false));
                    if (parent.def.defName == "BookOfArcanist")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfValiant" || parent.def.defName == "Torn_BookOfValiant")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Paladin"), 4, false));
                    if (parent.def.defName == "BookOfValiant")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfSummoner" || parent.def.defName == "Torn_BookOfSummoner")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Summoner"), 4, false));
                    if (parent.def.defName == "BookOfSummoner")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfDruid" || parent.def.defName == "Torn_BookOfNature")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Druid"), 4, false));
                    if (parent.def.defName == "BookOfDruid")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfNecromancer" || parent.def.defName == "Torn_BookOfUndead")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Necromancer"), 4, false));
                    if (parent.def.defName == "BookOfNecromancer")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfPriest" || parent.def.defName == "Torn_BookOfPriest")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    FixPriestSkills(user);
                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Priest"), 4, false));
                    if (parent.def.defName == "BookOfPriest")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfBard" || parent.def.defName == "Torn_BookOfBard")
                {
                    if (!user.story.WorkTagIsDisabled(WorkTags.Social))
                    {
                        FixTrait(user, user.story.traits.allTraits);
                        FixBardSkills(user);
                        user.story.traits.GainTrait(new Trait(TraitDef.Named("TM_Bard"), 0, false));
                        if (parent.def.defName == "BookOfBard")
                        {
                            HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                        }
                        this.parent.Destroy(DestroyMode.Vanish);
                    }
                    else
                    {
                        Messages.Message("TM_NotSocialCapable".Translate(
                            user.LabelShort
                        ), MessageTypeDefOf.RejectInput);
                    }

                }
                else if (parent.def.defName == "BookOfDemons" || parent.def.defName == "Torn_BookOfDemons")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    if (user.gender == Gender.Male)
                    {
                        user.story.traits.GainTrait(new Trait(TraitDef.Named("Warlock"), 4, false));
                    }
                    else if (user.gender == Gender.Female)
                    {
                        user.story.traits.GainTrait(new Trait(TraitDef.Named("Succubus"), 4, false));
                    }
                    else
                    {
                        Log.Message("No gender found - assigning random trait.");
                        if(Rand.Chance(.5f))
                        {
                            user.story.traits.GainTrait(new Trait(TraitDef.Named("Succubus"), 4, false));
                        }
                        else
                        {
                            user.story.traits.GainTrait(new Trait(TraitDef.Named("Warlock"), 4, false));
                        }
                    }
                    if (parent.def.defName == "BookOfDemons")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfEarth" || parent.def.defName == "Torn_BookOfEarth")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Geomancer"), 4, false));
                    if (parent.def.defName == "BookOfEarth")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfMagitech" || parent.def.defName == "Torn_BookOfMagitech")
                {
                    FixTrait(user, user.story.traits.allTraits);
                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Technomancer"), 4, false));
                    if (parent.def.defName == "BookOfMagitech")
                    {
                        HealthUtility.AdjustSeverity(user, TorannMagicDefOf.TM_Uncertainty, 0.2f);
                    }
                    this.parent.Destroy(DestroyMode.Vanish);
                }
                else if (parent.def.defName == "BookOfQuestion")
                {
                    int attempts = 0;
                    ModOptions.SettingsRef settingsRef = new ModOptions.SettingsRef();
                    FixTrait(user, user.story.traits.allTraits);
                    RetryBookOfQuestion:;
                    if (attempts < 50)
                    {
                        int rnd = Mathf.RoundToInt(Rand.RangeInclusive(0, 13));
                        switch (rnd)
                        {
                            case 0:
                                if (settingsRef.Demonkin)
                                {
                                    if (user.gender == Gender.Male)
                                    {
                                        user.story.traits.GainTrait(new Trait(TraitDef.Named("Warlock"), 4, false));
                                    }
                                    else if (user.gender == Gender.Female)
                                    {
                                        user.story.traits.GainTrait(new Trait(TraitDef.Named("Succubus"), 4, false));
                                    }
                                    else
                                    {
                                        Log.Message("No gender found.");
                                    }
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 13:
                                if (settingsRef.Demonkin)
                                {
                                    if (user.gender == Gender.Male)
                                    {
                                        user.story.traits.GainTrait(new Trait(TraitDef.Named("Warlock"), 4, false));
                                    }
                                    else if (user.gender == Gender.Female)
                                    {
                                        user.story.traits.GainTrait(new Trait(TraitDef.Named("Succubus"), 4, false));
                                    }
                                    else
                                    {
                                        Log.Message("No gender found.");
                                    }
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;                                
                            case 1:
                                if (settingsRef.Necromancer)
                                {
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Necromancer"), 4, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 2:
                                if(settingsRef.Druid)
                                { 
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Druid"), 4, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 3:
                                if(settingsRef.Summoner)
                                { 
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Summoner"), 4, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 4:
                                if(settingsRef.FireMage)
                                { 
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("InnerFire"), 4, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 5:
                                if (settingsRef.IceMage)
                                {
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("HeartOfFrost"), 4, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 6:
                                if (settingsRef.LitMage)
                                {
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("StormBorn"), 4, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 7:
                                if (settingsRef.Arcanist)
                                {
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Arcanist"), 4, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 8:
                                if (settingsRef.Priest)
                                {
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Priest"), 4, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 9:
                                if (settingsRef.Bard)
                                {
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("TM_Bard"), 0, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 10:
                                if (settingsRef.Paladin)
                                {
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Paladin"), 4, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 11:
                                if (settingsRef.Geomancer)
                                {
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Geomancer"), 4, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                            case 12:
                                if (settingsRef.Technomancer)
                                {
                                    user.story.traits.GainTrait(new Trait(TraitDef.Named("Technomancer"), 4, false));
                                }
                                else
                                {
                                    attempts++;
                                    goto RetryBookOfQuestion;
                                }
                                break;
                        }
                        this.parent.Destroy(DestroyMode.Vanish);
                    }
                    else
                    {
                        user.story.traits.GainTrait(new Trait(TraitDef.Named("Gifted"), 2, false));
                        Messages.Message("Unable to find a valid class to assign after 50 attempts - ending attempt", MessageTypeDefOf.RejectInput);
                    }                 
                }
                else
                {
                    Messages.Message("NotArcaneBook".Translate(), MessageTypeDefOf.RejectInput);
                }

            }
            else
            {
                Messages.Message("NotGiftedPawn".Translate(
                        user.LabelShort
                    ), MessageTypeDefOf.RejectInput);
            }

		}

        private void FixTrait(Pawn pawn, List<Trait> traits)
        {
            for (int i = 0; i < traits.Count; i++)
            {
                if (traits[i].def.defName == "Gifted")
                {
                    traits.Remove(traits[i]);
                    i--;
                }
                
            }
        }

        private void FixPriestSkills(Pawn pawn)
        {
            SkillRecord skill;
            skill = pawn.skills.GetSkill(SkillDefOf.Shooting);
            skill.passion = Passion.None;
            skill = pawn.skills.GetSkill(SkillDefOf.Melee);
            skill.passion = Passion.None;
            pawn.workSettings.SetPriority(WorkTypeDefOf.Hunting, 0);
            skill = pawn.skills.GetSkill(SkillDefOf.Medicine);
            if(skill.passion == Passion.None)
            {
                skill.passion = Passion.Minor;
            }
        }

        private void FixBardSkills(Pawn pawn)
        {
            SkillRecord skill;
            pawn.workSettings.SetPriority(TorannMagicDefOf.Cleaning, 0);
            pawn.workSettings.SetPriority(TorannMagicDefOf.Hauling, 0);
            pawn.workSettings.SetPriority(TorannMagicDefOf.PlantCutting, 0);
            skill = pawn.skills.GetSkill(SkillDefOf.Social);
            if(skill.passion == Passion.Minor)
            {
                skill.passion = Passion.Major;
            }
            if (skill.passion == Passion.None)
            {
                skill.passion = Passion.Minor;
            }
        }
    }
}
