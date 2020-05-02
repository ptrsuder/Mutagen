using Loqui;
using Mutagen.Bethesda.Oblivion;

namespace Loqui
{
    public class ProtocolDefinition_Oblivion : IProtocolRegistration
    {
        public readonly static ProtocolKey ProtocolKey = new ProtocolKey("Oblivion");
        void IProtocolRegistration.Register() => Register();
        public static void Register()
        {
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ModStats_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ModHeader_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.OblivionMod_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.GameSetting_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.GameSettingInt_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.GameSettingFloat_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.GameSettingString_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Global_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.GlobalInt_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.GlobalShort_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.GlobalFloat_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Class_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ClassTraining_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Model_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Hair_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Faction_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Relation_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Rank_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Race_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SkillBoost_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SpellUnleveled_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Eye_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RaceStats_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.FacePart_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.BodyData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.BodyPart_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.FaceGenData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Sound_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SoundData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SoundDataExtended_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SkillRecord_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.MagicEffect_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Script_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ScriptMetaSummary_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LocalVariable_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ScriptReference_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LandTexture_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.HavokData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Effect_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ScriptEffect_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Enchantment_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.MagicEffectSubData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.EffectShader_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Grass_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Light_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ScriptVariableReference_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ScriptObjectReference_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Birthsign_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Spell_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SpellLeveled_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Activator_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AlchemicalApparatus_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Armor_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Book_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AClothing_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Clothing_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Container_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ContainerItem_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AItem_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Door_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Worldspace_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Ingredient_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Miscellaneous_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Static_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Tree_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Flora_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Furniture_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Weapon_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Ammunition_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Npc_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RankPlacement_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ItemEntry_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AIPackage_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.CombatStyle_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Creature_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.CreatureSound_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SoundItem_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LeveledEntry_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LeveledCreature_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ANpc_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.NpcSpawn_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SoulGem_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Key_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Potion_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Subspace_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SigilStone_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LeveledItem_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Weather_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.WeatherType_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.WeatherSound_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Climate_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.WeatherChance_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Region_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RegionArea_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RegionData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RegionDataObjects_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RegionDataMapName_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RegionDataGrasses_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RegionDataSounds_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RegionDataWeather_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RegionDataObject_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RegionSound_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Cell_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.PlacedObject_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.TeleportDestination_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LockInformation_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.EnableParent_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.DistantLODData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.MapMarker_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Water_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.PlacedCreature_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.PathGrid_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.PathGridPoint_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.CellBlock_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.CellSubBlock_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.InterCellPoint_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.PointToReferenceMapping_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.PlacedNpc_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.CellLighting_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Road_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.WorldspaceBlock_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.WorldspaceSubBlock_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RoadPoint_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Landscape_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AlphaLayer_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.BaseLayer_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.MapData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.DialogTopic_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Quest_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.DialogItem_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.DialogResponse_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Condition_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ScriptFields_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LogEntry_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.QuestTarget_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.QuestStage_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.IdleAnimation_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AIPackageLocation_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AIPackageSchedule_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AIPackageTarget_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.CombatStyleAdvanced_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LoadScreen_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LoadScreenLocation_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Place_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LeveledSpell_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AnimatedObject_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RelatedWaters_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RaceRelation_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ASpell_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.OblivionMajorRecord_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Group_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ListGroup_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ClothingFlags_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AIPackageData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AlchemicalApparatusData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AmmunitionData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ArmorData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.BookData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ClassData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ClimateData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ClothingData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.CombatStyleData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ContainerData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.CreatureConfiguration_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.CreatureAIData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.CreatureData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.DialogItemData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.DialogResponseData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.EffectShaderData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.EnchantmentData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SeasonalIngredientProduction_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.GrassData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.IngredientData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.KeyData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LayerHeader_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LightData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.MagicEffectData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.MiscellaneousData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.NpcConfiguration_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.AIData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.NpcData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Location_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.PotionData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.QuestTargetData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.QuestData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RaceData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.RegionDataHeader_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.LocalVariableData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SigilStoneData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SkillData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SoulGemData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.SpellData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.TreeData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.Dimensions_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.WaterData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.WeaponData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.FogDistance_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.HDRData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.WeatherData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.EffectData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Oblivion.Internals.ScriptEffectData_Registration.Instance);
        }
    }
}
