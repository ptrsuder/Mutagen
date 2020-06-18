﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Skyrim
{
    /// <summary>
    /// An abstract class representing a Perk entry point effect.
    /// Implemented by: [PerkModifyValue, PerkAddRangeToValue, PerkModifyActorValue, PerkAbsoluteValue
    /// PerkAddLeveledItem, PerkAddActivateChoice, PerkSelectSpell, PerkSelectText, PerkSetText]
    /// </summary>
    public partial class APerkEntryPointEffect
    {
        public enum EntryType
        {
            CalculateWeaponDamage = 0,
            CalculateMyCriticalHitChance = 1,
            CalculateMyCriticalHitDamage = 2,
            CalculateMineExplodeChance = 3,
            AdjustLimbDamage = 4,
            AdjustBookSkillPoints = 5,
            ModRecoveredHealth = 6,
            GetShouldAttack = 7,
            ModBuyPrices = 8,
            AddLeveledListOnDeath = 9,
            GetMaxCarryWeight = 10,
            ModAddictionChance = 11,
            ModAddictionDuration = 12,
            ModPositiveChemDuration = 13,
            Activate = 14,
            IgnoreRunningDurationDetection = 15,
            IgnoreBrokenLock = 16,
            ModEnemyCriticalHitChance = 17,
            ModSneakAttackMult = 18,
            ModMaxPlacableMinex = 19,
            ModBowZoom = 20,
            ModRecoverArrowChance = 21,
            ModSkillUse = 22,
            ModTelekinesisDistance = 23,
            ModTelekinesisDamageMult = 24,
            ModTelekinesisDamage = 25,
            ModBashingDamage = 26,
            ModPowerAttackStamina = 27,
            ModPowerAttackDamage = 28,
            ModSpellMagnitude = 29,
            ModSpellDuration = 30,
            ModSecondaryValueWeight = 31,
            ModArmorWeight = 32,
            ModIncomingStagger = 33,
            ModTargetStagger = 34,
            ModAttackDamage = 35,
            ModIncomingDamage = 36,
            ModTargetDamageResistance = 37,
            ModSpellCost = 38,
            ModPercentBlocked = 39,
            ModShieldDefectArrowChance = 40,
            ModIncomingSpellMagnitude = 41,
            ModIncomingSpellDuration = 42,
            ModPlayerIntimidation = 43,
            ModPlayerReputation = 44,
            ModFavorPoints = 45,
            ModBribeAmount = 46,
            ModDetectionLight = 47,
            ModSoulGemRecharge = 49,
            SetSweepAttack = 50,
            ApplyCombatHitSpell = 51,
            ApplyBashingSpell = 52,
            ApplyReanimateSpell = 53,
            SetBooleanGraphVariable = 54,
            ModSpellCastingSoundEvent = 55,
            ModPickpocketChance = 56,
            ModDetectionSneakSkill = 57,
            ModFallingDamage = 58,
            ModLockpickSweetSpot = 59,
            ModSellPrices = 60,
            CanPickpocketEquippedItem = 61,
            ModLockpicLevelAllowed = 62,
            SetLockpickStartingArc = 63,
            SetProgressionPicking = 64,
            MakeLockpicksUnbreakable = 65,
            ModAlchemyEffectiveness = 66,
            ApplyWeaponSwingSpell = 67,
            ModCommandedActorLimit = 68,
            ApplySneakingSpell = 69,
            ModPlayerMagicSlowdown = 70,
            ModWardMagickaAbsorptionPct = 71,
            ModInitialIngredientEffectsLearned = 72,
            PurifyAlchemyIngredients = 73,
            FilterActivation = 74,
            CanDualCastSpell = 75,
            ModTemperingHealth = 76,
            ModEnchantmentPower = 77,
            ModSoulPercentCapturedToWeapon = 78,
            ModSoulGemEnchanting = 79,
            ModNumAppliedEnchantmentsAllowed = 80,
            SetActivateLabel = 81,
            ModShoutOk = 82,
            ModPoisonDoseCount = 83,
            ShouldApplyPlacedItem = 84,
            ModArmorRating = 85,
            ModLockpickingCrimeChance = 86,
            ModIngredientsHarvested = 87,
            ModSpellRange = 88,
            ModPotionsCreated = 89,
            ModLockpickingKeyRewardChance = 90,
            AllowMountActor = 91,
        }

        public enum FunctionType
        {
            SetValue = 1,
            AddValue = 2,
            MultiplyValue = 3,
            AddRangeToValue = 4,
            AddActorValueMult = 5,
            AbsoluteValue = 6,
            NegativeAbsoluteValue = 7,
            AddLeveledList = 8,
            AddActivateChoice = 9,
            SelectSpell = 10,
            SelectText = 11,
            SetToActorValueMult = 12,
            MultiplyActorValueMult = 13,
            MultiplyOnePlusActorValueMult = 14,
            SetText = 15,
        }

        public enum ParameterType
        {
            None = 0,
            Float = 1,
            FloatFloat = 2,
            LeveledItem = 3,
            SpellWithStrings = 4,
            Spell = 5,
            String = 6,
            LString = 7,
        }
    }
}
