﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
using UnityEngine;
using Verse;
using Verse.AI;
using RimWorld;
using AbilityUser;

namespace TorannMagic.AutoCast
{
    public static class CombatAbility_OnTarget
    {
        public static void TryExecute(CompAbilityUserMight casterComp, TMAbilityDef abilitydef, PawnAbility ability, MightPower power, LocalTargetInfo target, int minRange, out bool success)
        {
            success = false;
            if (casterComp.Stamina.CurLevel >= abilitydef.staminaCost && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = casterComp.Pawn;
                LocalTargetInfo jobTarget = target;
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
                if (distanceToTarget > minRange && distanceToTarget < (abilitydef.MainVerb.range * .9f) && jobTarget != null && jobTarget.Thing != null)
                {
                    Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                    caster.jobs.TryTakeOrderedJob(job);
                    success = true;
                }
            }
        }
    }

    public static class AoECombat
    {
        public static void Evaluate(CompAbilityUserMight mightComp, TMAbilityDef abilitydef, PawnAbility ability, MightPower power, int minTargetCount, int radiusAround, IntVec3 evaluatedCenter, bool hostile, out bool success)
        {
            success = false;
            if (mightComp.Stamina.CurLevel >= abilitydef.staminaCost && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = mightComp.Pawn;
                List<Pawn> targetList = TM_Calc.FindPawnsNearTarget(caster, radiusAround, evaluatedCenter, hostile);
                LocalTargetInfo jobTarget = null;
                if (targetList.Count >= minTargetCount)
                {
                    jobTarget = caster;
                }
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
                if (jobTarget != null && jobTarget.Thing != null)
                {
                    Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                    caster.jobs.TryTakeOrderedJob(job);
                    success = true;
                }
            }
        }
    }

    public static class CombatAbility
    {
        public static void Evaluate(CompAbilityUserMight casterComp, TMAbilityDef abilitydef, PawnAbility ability, MightPower power, out bool success)
        {
            success = false;
            EvaluateMinRange(casterComp, abilitydef, ability, power, 3f, out success);
        }

        public static void EvaluateMinRange(CompAbilityUserMight casterComp, TMAbilityDef abilitydef, PawnAbility ability, MightPower power, float minRange, out bool success)
        {
            success = false;
            if (casterComp.Stamina.CurLevel >= abilitydef.staminaCost && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = casterComp.Pawn;
                LocalTargetInfo jobTarget = TM_Calc.FindNearbyEnemy(caster, (int)(abilitydef.MainVerb.range * .9f));
                if(abilitydef == TorannMagicDefOf.TM_AntiArmor)
                {
                    Pawn targetPawn = jobTarget.Thing as Pawn;
                    if(targetPawn.RaceProps.IsFlesh)
                    {
                        jobTarget = null;
                    }
                }
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
                if (distanceToTarget > minRange && distanceToTarget < (abilitydef.MainVerb.range * .9f) && jobTarget != null && jobTarget.Thing != null)
                {
                    Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                    caster.jobs.TryTakeOrderedJob(job);
                    success = true;
                }
            }
        }
    }

    public static class CureSpell
    {
        public static void Evaluate(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, List<string> validAfflictionNames, out bool success)
        {
            success = false;
            if (casterComp.Mana.CurLevel >= casterComp.ActualManaCost(abilitydef) && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = casterComp.Pawn;
                LocalTargetInfo jobTarget = TM_Calc.FindNearbyAfflictedPawn(caster, (int)(abilitydef.MainVerb.range * .9f), validAfflictionNames);
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
                if (distanceToTarget < (abilitydef.MainVerb.range * .9f) && jobTarget != null && jobTarget.Thing != null)
                {
                    Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                    caster.jobs.TryTakeOrderedJob(job);
                    success = true;
                }
            }
        }
    }

    public static class HealSpell
    {
        public static void Evaluate(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, out bool success)
        {
            success = false;
            EvaluateMinSeverity(casterComp, abilitydef, ability, power, 0, out success);
        }

        public static void EvaluateMinSeverity(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, float minSeverity, out bool success)
        {
            success = false;
            if (casterComp.Mana.CurLevel >= casterComp.ActualManaCost(abilitydef) && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = casterComp.Pawn;
                LocalTargetInfo jobTarget = TM_Calc.FindNearbyInjuredPawn(caster, (int)(abilitydef.MainVerb.range * .9f), minSeverity);
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;                
                if (distanceToTarget < (abilitydef.MainVerb.range * .9f) && jobTarget != null && jobTarget.Thing != null)
                {
                    if (abilitydef == TorannMagicDefOf.TM_CauterizeWound)
                    {
                        Pawn targetPawn = jobTarget.Thing as Pawn;
                        if (targetPawn.health.HasHediffsNeedingTend(false))
                        {
                            Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                            caster.jobs.TryTakeOrderedJob(job);
                            success = true;
                        }
                    }
                    else
                    {
                        Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                        caster.jobs.TryTakeOrderedJob(job);
                        success = true;
                    }                    
                }
            }
        }
    }

    public static class HediffHealSpell
    {
        public static void Evaluate(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, HediffDef hediffDef, out bool success)
        {
            success = false;
            EvaluateMinSeverity(casterComp, abilitydef, ability, power, hediffDef, 0, out success);
        }

        public static void EvaluateMinSeverity(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, HediffDef hediffDef, float minSeverity, out bool success)
        {
            success = false;
            if (casterComp.Mana.CurLevel >= casterComp.ActualManaCost(abilitydef) && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = casterComp.Pawn;
                LocalTargetInfo jobTarget = TM_Calc.FindNearbyInjuredPawn(caster, (int)(abilitydef.MainVerb.range * .9f), minSeverity);
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
                if (distanceToTarget < (abilitydef.MainVerb.range * .9f) && jobTarget != null && jobTarget.Thing != null && jobTarget.Thing is Pawn)
                {
                    Pawn targetPawn = jobTarget.Thing as Pawn;
                    if (!targetPawn.health.hediffSet.HasHediff(hediffDef, false))
                    {
                        Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                        caster.jobs.TryTakeOrderedJob(job);
                        success = true;
                    }
                }
            }
        }
    }

    public static class HediffSpell
    {
        public static void Evaluate(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, HediffDef hediffDef, out bool success)
        {
            success = false;
            EvaluateMinRange(casterComp, abilitydef, ability, power, hediffDef, 6f, out success);
        }

        public static void EvaluateMinRange(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, HediffDef hediffDef, float minRange, out bool success)
        {
            success = false;
            if (casterComp.Mana.CurLevel >= casterComp.ActualManaCost(abilitydef) && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = casterComp.Pawn;
                LocalTargetInfo jobTarget = TM_Calc.FindNearbyEnemy(caster, (int)(abilitydef.MainVerb.range * .9f));
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
                if (distanceToTarget > minRange && distanceToTarget < (abilitydef.MainVerb.range * .9f) && jobTarget != null && jobTarget.Thing != null && jobTarget.Thing is Pawn)
                {
                    Pawn targetPawn = jobTarget.Thing as Pawn;
                    if (!targetPawn.health.hediffSet.HasHediff(hediffDef, false))
                    {
                        Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                        caster.jobs.TryTakeOrderedJob(job);
                        success = true;
                    }
                }
            }
        }
    }

    public static class DamageSpell
    {
        public static void Evaluate(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, out bool success)
        {
            success = false;
            EvaluateMinRange(casterComp, abilitydef, ability, power, 6f, out success);
        }

        public static void EvaluateMinRange(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, float minRange, out bool success)
        {
            success = false;
            if (casterComp.Mana.CurLevel >= casterComp.ActualManaCost(abilitydef) && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = casterComp.Pawn;
                LocalTargetInfo jobTarget = TM_Calc.FindNearbyEnemy(caster, (int)(abilitydef.MainVerb.range * .9f));
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
                if (distanceToTarget > minRange && distanceToTarget < (abilitydef.MainVerb.range * .9f) && jobTarget != null && jobTarget.Thing != null)
                {
                    Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                    caster.jobs.TryTakeOrderedJob(job);
                    success = true;
                }
            }
        }
    }

    public static class TransferManaSpell
    {
        public static void Evaluate(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, bool inCombat, bool reverse, out bool success) //reverse == true transfers mana to caster
        {
            success = false;
            if (casterComp.Mana.CurLevel >= casterComp.ActualManaCost(abilitydef) && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = casterComp.Pawn;
                LocalTargetInfo jobTarget = TM_Calc.FindNearbyMage(caster, (int)(abilitydef.MainVerb.range * .9f), inCombat);
                if (!inCombat)
                {
                    Pawn transferPawn = jobTarget.Thing as Pawn;
                    CompAbilityUserMagic tComp = transferPawn.GetComp<CompAbilityUserMagic>();
                    if (reverse)
                    {                        
                        if(casterComp.Mana.CurLevel >= .3f || tComp.Mana.CurLevel <= .9f)
                        {
                            jobTarget = null;
                        }
                    }
                    else
                    {
                        if(casterComp.Mana.CurLevel <= .9f || tComp.Mana.CurLevel >= .9f)
                        {
                            jobTarget = null;
                        }
                    }
                }
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
                if (distanceToTarget < (abilitydef.MainVerb.range * .9f) && jobTarget != null && jobTarget.Thing != null)
                {
                    Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                    caster.jobs.TryTakeOrderedJob(job);
                    success = true;
                }
            }
        }
    }

    public static class Summon
    {
        public static void Evaluate(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, float minDistance, out bool success)
        {
            success = false;
            Pawn caster = casterComp.Pawn;
            LocalTargetInfo jobTarget = caster.CurJob.targetA;
            float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
            Vector3 directionToTarget = TM_Calc.GetVector(caster.Position, jobTarget.Cell);

            if (casterComp.Mana.CurLevel >= casterComp.ActualManaCost(abilitydef) && ability.CooldownTicksLeft <= 0 && jobTarget.Thing != null && jobTarget.Thing.def.EverHaulable)
            {
                //Log.Message("summon: " + caster.LabelShort + " job def is " + caster.CurJob.def.defName + " targetA " + caster.CurJob.targetA + " targetB " + caster.CurJob.targetB + " jobTarget " + jobTarget + " at distance " + distanceToTarget + " min distance " + minDistance + " at vector " + directionToTarget);
                if (distanceToTarget > minDistance && distanceToTarget < abilitydef.MainVerb.range && caster.CurJob.locomotionUrgency >= LocomotionUrgency.Jog && caster.CurJob.bill == null && distanceToTarget < 200)
                {
                    Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                    caster.jobs.TryTakeOrderedJob(job);
                    success = true;
                }
            }
        }
    }

    public static class Shield
    {
        public static void Evaluate(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, out bool success)
        {
            success = false;
            Pawn caster = casterComp.Pawn;
            LocalTargetInfo jobTarget = caster;

            if (casterComp.Mana.CurLevel >= casterComp.ActualManaCost(abilitydef) && ability.CooldownTicksLeft <= 0 && jobTarget.Thing != null)
            {
                float injurySeverity = 0;
                using (IEnumerator<BodyPartRecord> enumerator = caster.health.hediffSet.GetInjuredParts().GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        BodyPartRecord rec = enumerator.Current;
                        IEnumerable<Hediff_Injury> arg_BB_0 = caster.health.hediffSet.GetHediffs<Hediff_Injury>();
                        Func<Hediff_Injury, bool> arg_BB_1;
                        arg_BB_1 = ((Hediff_Injury injury) => injury.Part == rec);

                        foreach (Hediff_Injury current in arg_BB_0.Where(arg_BB_1))
                        {
                            bool flag5 = current.CanHealNaturally() && !current.IsPermanent();
                            if (flag5)
                            {
                                injurySeverity += current.Severity;
                            }
                        }
                    }
                }
                if (injurySeverity != 0 && !(caster.health.hediffSet.HasHediff(HediffDef.Named("TM_HediffShield"))))
                {
                    Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                    caster.jobs.TryTakeOrderedJob(job);
                    success = true;
                }            
            }
        }
    }

    public static class SpellMending
    {
        public static void Evaluate(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, HediffDef hediffDef, out bool success)
        {
            success = false;
            if (casterComp.Mana.CurLevel >= casterComp.ActualManaCost(abilitydef) && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = casterComp.Pawn;
                LocalTargetInfo jobTarget = TM_Calc.FindNearbyPawn(caster, (int)(abilitydef.MainVerb.range * .9f));
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;                
                if (distanceToTarget < (abilitydef.MainVerb.range * .9f) && jobTarget != null && jobTarget.Thing != null && jobTarget.Thing is Pawn)
                {
                    Pawn targetPawn = jobTarget.Thing as Pawn;
                    if (targetPawn.RaceProps.Humanlike && targetPawn.IsColonist)
                    {
                        bool tatteredApparel = false;
                        //List<Thought_Memory> targetPawnThoughts = null;
                        //targetPawn.needs.mood.thoughts.GetDistinctMoodThoughtGroups(targetPawnThoughts);
                        List<Thought_Memory> targetPawnThoughts = targetPawn.needs.mood.thoughts.memories.Memories;
                        for (int i = 0; i < targetPawnThoughts.Count; i++)
                        {
                            if (targetPawnThoughts[i].def == ThoughtDefOf.ApparelDamaged)
                            {
                                tatteredApparel = true;
                            }
                        }
                        if (!targetPawn.health.hediffSet.HasHediff(hediffDef, false) && tatteredApparel)
                        {
                            Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                            caster.jobs.TryTakeOrderedJob(job);
                            success = true;
                        }
                    }
                }
            }
        }
    }

    public static class Teach
    {
        public static void Evaluate(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, out bool success)
        {
            success = false;
            if (casterComp.Mana.CurLevel >= casterComp.ActualManaCost(abilitydef) && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = casterComp.Pawn;
                LocalTargetInfo jobTarget = TM_Calc.FindNearbyMage(caster, (int)(abilitydef.MainVerb.range * .9f), false);
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
                if (distanceToTarget < (abilitydef.MainVerb.range * .9f) && jobTarget != null && jobTarget.Thing != null && jobTarget.Thing is Pawn)
                {
                    Pawn targetPawn = jobTarget.Thing as Pawn;

                    if (targetPawn.IsColonist)
                    {
                        Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                        caster.jobs.TryTakeOrderedJob(job);
                        success = true;
                    }
                }
            }
        }
    }

    public static class TeachMight
    {
        public static void Evaluate(CompAbilityUserMight casterComp, TMAbilityDef abilitydef, PawnAbility ability, MightPower power, out bool success)
        {
            success = false;
            if (casterComp.Stamina.CurLevel >= abilitydef.staminaCost && ability.CooldownTicksLeft <= 0)
            {
                Pawn caster = casterComp.Pawn;
                LocalTargetInfo jobTarget = TM_Calc.FindNearbyFighter(caster, (int)(abilitydef.MainVerb.range * .9f), false);
                float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
                if (distanceToTarget < (abilitydef.MainVerb.range * .9f) && jobTarget != null && jobTarget.Thing != null && jobTarget.Thing is Pawn)
                {
                    Pawn targetPawn = jobTarget.Thing as Pawn;

                    if (targetPawn.IsColonist)
                    {
                        Job job = ability.GetJob(AbilityContext.AI, jobTarget);
                        caster.jobs.TryTakeOrderedJob(job);
                        success = true;
                    }
                }
            }
        }
    }

    public static class Blink
    {
        public static void Evaluate(CompAbilityUserMagic casterComp, TMAbilityDef abilitydef, PawnAbility ability, MagicPower power, float minDistance, out bool success)
        {
            success = false;
            Pawn caster = casterComp.Pawn;
            LocalTargetInfo jobTarget = caster.CurJob.targetA;
            Thing carriedThing = null;
            if (caster.CurJob.targetA.Thing != null ) //&& caster.CurJob.def.defName != "Sow")
            {
                if(caster.CurJob.targetA.Thing.Map != caster.Map) //carrying thing
                {
                    jobTarget = caster.CurJob.targetB;
                    carriedThing = caster.CurJob.targetA.Thing;
                }
                else if(caster.CurJob.targetB != null && caster.CurJob.targetB.Thing != null && caster.CurJob.def.defName != "Rescue") //targetA using targetB for job
                {
                    if(caster.CurJob.targetB.Thing.Map != caster.Map) //carrying targetB to targetA
                    {
                        jobTarget = caster.CurJob.targetA;
                        carriedThing = caster.CurJob.targetB.Thing;
                    }
                    else //Getting targetB
                    {
                        jobTarget = caster.CurJob.targetB;
                    }
                }
                else
                {
                    jobTarget = caster.CurJob.targetA;
                }
            }
            float distanceToTarget = (jobTarget.Cell - caster.Position).LengthHorizontal;
            Vector3 directionToTarget = TM_Calc.GetVector(caster.Position, jobTarget.Cell);
            //Log.Message("" + caster.LabelShort + " job def is " + caster.CurJob.def.defName + " targetA " + caster.CurJob.targetA + " targetB " + caster.CurJob.targetB + " jobTarget " + jobTarget + " at distance " + distanceToTarget + " min distance " + minDistance + " at vector " + directionToTarget);
            if (casterComp.Mana.CurLevel >= casterComp.ActualManaCost(abilitydef) && ability.CooldownTicksLeft <= 0 && distanceToTarget < 200)
            {
                if (distanceToTarget > minDistance && caster.CurJob.locomotionUrgency >= LocomotionUrgency.Jog && caster.CurJob.bill == null)
                {
                    if (distanceToTarget <= abilitydef.MainVerb.range && jobTarget.Cell != default(IntVec3))
                    {
                        //Log.Message("doing blink to thing");
                        DoBlink(caster, jobTarget.Cell, ability, carriedThing);
                        success = true;
                    }
                    else
                    {
                        IntVec3 blinkToCell = caster.Position + (directionToTarget * abilitydef.MainVerb.range).ToIntVec3();
                        //Log.Message("doing partial blink to cell " + blinkToCell);
                        //MoteMaker.ThrowHeatGlow(blinkToCell, caster.Map, 1f);
                        if (blinkToCell.IsValid && blinkToCell.InBounds(caster.Map) && blinkToCell.Walkable(caster.Map) && !blinkToCell.Fogged(caster.Map) && ((blinkToCell - caster.Position).LengthHorizontal < distanceToTarget))
                        {
                            DoBlink(caster, blinkToCell, ability, carriedThing);
                            success = true;
                        }
                    }
                }
            }
        }

        private static void DoBlink(Pawn caster, IntVec3 targetCell, PawnAbility ability, Thing carriedThing)
        {
            Pawn p = caster;
            Thing cT = carriedThing;
            Map map = caster.Map;
            IntVec3 casterCell = caster.Position;
            bool selectCaster = false;
            if (Find.Selector.FirstSelectedObject == caster)
            {
                selectCaster = true;
            }
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    TM_MoteMaker.ThrowGenericMote(ThingDefOf.Mote_Smoke, caster.DrawPos, caster.Map, Rand.Range(.6f, 1f), .4f, .1f, Rand.Range(.8f, 1.2f), 0, Rand.Range(2, 3), Rand.Range(-30, 30), 0);
                    TM_MoteMaker.ThrowGenericMote(TorannMagicDefOf.Mote_Casting, caster.DrawPos, caster.Map, Rand.Range(1.4f, 2f), .2f, .05f, Rand.Range(.4f, .6f), Rand.Range(-200, 200), 0, 0, 0);
                }
                
                caster.DeSpawn();                
                GenSpawn.Spawn(p, targetCell, map);
                if(carriedThing != null)
                {
                    carriedThing.DeSpawn();
                    GenSpawn.Spawn(cT, targetCell, map);
                }
                
                ability.PostAbilityAttempt();
                if(selectCaster)
                {
                    Find.Selector.Select(caster, false, true);
                }
                for (int i = 0; i < 3; i++)
                {
                    TM_MoteMaker.ThrowGenericMote(ThingDefOf.Mote_Smoke, caster.DrawPos, caster.Map, Rand.Range(.6f, 1f), .4f, .1f, Rand.Range(.8f, 1.2f), 0, Rand.Range(2, 3), Rand.Range(-30, 30), 0);
                    TM_MoteMaker.ThrowGenericMote(TorannMagicDefOf.Mote_Casting, caster.DrawPos, caster.Map, Rand.Range(1.4f, 2f), .2f, .05f, Rand.Range(.4f, .6f), Rand.Range(-200, 200), 0, 0, 0);
                }
            }
            catch
            {
                if (!caster.Spawned)
                {
                    GenSpawn.Spawn(p, casterCell, map);
                }
            }
        }
    }    
}
