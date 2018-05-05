//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Sakuno.ING.Game.Models.MasterData
{
    public partial class ShipInfo : Calculated<IRawShipInfo>
    {
        public ShipInfo(int id, ITableProvider owner) : base(id, owner)
        {
            shipTypeInfoTable = owner.GetTable<ShipTypeInfo>();
            shipInfoTable = owner.GetTable<ShipInfo>();
            NameTranslation = Module.Localize.GetLocalized("ShipName", id.ToString());
            IntroductionTranslation = Module.Localize.GetLocalized("ShipIntro", id.ToString());
            CreateDummy();
        }

        private readonly ITable<ShipTypeInfo> shipTypeInfoTable;

        private readonly ITable<ShipInfo> shipInfoTable;

        public string NameTranslation { get; }

        public string IntroductionTranslation { get; }

        private int _sortNo;
        public int SortNo
        {
            get => _sortNo;
            internal set => Set(ref _sortNo, value);
        }

        private string _phonetic;
        public string Phonetic
        {
            get => _phonetic;
            internal set => Set(ref _phonetic, value);
        }

        private ShipTypeInfo _type;
        public ShipTypeInfo Type
        {
            get => _type;
            internal set => Set(ref _type, value);
        }

        private int _classId;
        public int ClassId
        {
            get => _classId;
            internal set => Set(ref _classId, value);
        }

        private bool _canUpgrade;
        public bool CanUpgrade
        {
            get => _canUpgrade;
            internal set => Set(ref _canUpgrade, value);
        }

        private ShipInfo _upgradeTo;
        public ShipInfo UpgradeTo
        {
            get => _upgradeTo;
            internal set => Set(ref _upgradeTo, value);
        }

        private Materials _upgradeConsumption;
        public Materials UpgradeConsumption
        {
            get => _upgradeConsumption;
            internal set => Set(ref _upgradeConsumption, value);
        }

        private IReadOnlyCollection<ItemRecord> _upgradeSpecialConsumption;
        public IReadOnlyCollection<ItemRecord> UpgradeSpecialConsumption
        {
            get => _upgradeSpecialConsumption;
            internal set => Set(ref _upgradeSpecialConsumption, value);
        }

        private ShipMordenizationStatus _hP;
        public ShipMordenizationStatus HP
        {
            get => _hP;
            internal set => Set(ref _hP, value);
        }

        private ShipMordenizationStatus _armor;
        public ShipMordenizationStatus Armor
        {
            get => _armor;
            internal set => Set(ref _armor, value);
        }

        private ShipMordenizationStatus _firepower;
        public ShipMordenizationStatus Firepower
        {
            get => _firepower;
            internal set => Set(ref _firepower, value);
        }

        private ShipMordenizationStatus _torpedo;
        public ShipMordenizationStatus Torpedo
        {
            get => _torpedo;
            internal set => Set(ref _torpedo, value);
        }

        private ShipMordenizationStatus _antiAir;
        public ShipMordenizationStatus AntiAir
        {
            get => _antiAir;
            internal set => Set(ref _antiAir, value);
        }

        private ShipMordenizationStatus _luck;
        public ShipMordenizationStatus Luck
        {
            get => _luck;
            internal set => Set(ref _luck, value);
        }

        private ShipSpeed _speed;
        public ShipSpeed Speed
        {
            get => _speed;
            internal set => Set(ref _speed, value);
        }

        private FireRange _fireRange;
        public FireRange FireRange
        {
            get => _fireRange;
            internal set => Set(ref _fireRange, value);
        }

        private int _slotCount;
        public int SlotCount
        {
            get => _slotCount;
            internal set => Set(ref _slotCount, value);
        }

        private IReadOnlyList<int> _aircraft;
        public IReadOnlyList<int> Aircraft
        {
            get => _aircraft;
            internal set => Set(ref _aircraft, value);
        }

        private int? _totalAircraft;
        public int? TotalAircraft
        {
            get => _totalAircraft;
            internal set => Set(ref _totalAircraft, value);
        }

        private int _rarity;
        public int Rarity
        {
            get => _rarity;
            internal set => Set(ref _rarity, value);
        }

        private Materials _dismantleAcquirement;
        public Materials DismantleAcquirement
        {
            get => _dismantleAcquirement;
            internal set => Set(ref _dismantleAcquirement, value);
        }

        private TimeSpan _constructionTime;
        public TimeSpan ConstructionTime
        {
            get => _constructionTime;
            internal set => Set(ref _constructionTime, value);
        }

        private IReadOnlyList<int> _powerupWorth;
        public IReadOnlyList<int> PowerupWorth
        {
            get => _powerupWorth;
            internal set => Set(ref _powerupWorth, value);
        }

        private int _fuelConsumption;
        public int FuelConsumption
        {
            get => _fuelConsumption;
            internal set => Set(ref _fuelConsumption, value);
        }

        private int _bulletConsumption;
        public int BulletConsumption
        {
            get => _bulletConsumption;
            internal set => Set(ref _bulletConsumption, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            internal set => Set(ref _name, value);
        }

        private string _introduction;
        public string Introduction
        {
            get => _introduction;
            internal set => Set(ref _introduction, value);
        }

        public override void Update(IRawShipInfo raw)
        {
            SortNo = raw.SortNo;
            Phonetic = raw.Phonetic;
            ClassId = raw.ClassId;
            UpgradeConsumption = raw.UpgradeConsumption;
            UpgradeSpecialConsumption = raw.UpgradeSpecialConsumption;
            HP = raw.HP;
            Armor = raw.Armor;
            Firepower = raw.Firepower;
            Torpedo = raw.Torpedo;
            AntiAir = raw.AntiAir;
            Luck = raw.Luck;
            Speed = raw.Speed;
            FireRange = raw.FireRange;
            SlotCount = raw.SlotCount;
            Aircraft = raw.Aircraft;
            Rarity = raw.Rarity;
            DismantleAcquirement = raw.DismantleAcquirement;
            ConstructionTime = raw.ConstructionTime;
            PowerupWorth = raw.PowerupWorth;
            FuelConsumption = raw.FuelConsumption;
            BulletConsumption = raw.BulletConsumption;
            Name = raw.Name;
            Introduction = raw.Introduction;
            UpdateCore(raw);
        }
        partial void UpdateCore(IRawShipInfo raw);
        partial void CreateDummy();
    }
    public partial class ShipTypeInfo : Calculated<IRawShipTypeInfo>
    {
        public ShipTypeInfo(int id, ITableProvider owner) : base(id, owner)
        {
            equipmentTypeInfoTable = owner.GetTable<EquipmentTypeInfo>();
            NameTranslation = Module.Localize.GetLocalized("ShipType", id.ToString());
            _unlocalizedName = Module.Localize.GetUnlocalized("ShipType", id.ToString());
            CreateDummy();
        }

        private readonly ITable<EquipmentTypeInfo> equipmentTypeInfoTable;

        public string NameTranslation { get; }
        private readonly string _unlocalizedName;

        private int _sortNo;
        public int SortNo
        {
            get => _sortNo;
            internal set => Set(ref _sortNo, value);
        }

        private int _repairTimeRatio;
        public int RepairTimeRatio
        {
            get => _repairTimeRatio;
            internal set => Set(ref _repairTimeRatio, value);
        }

        private int _buildOutlineId;
        public int BuildOutlineId
        {
            get => _buildOutlineId;
            internal set => Set(ref _buildOutlineId, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            internal set => Set(ref _name, value);
        }

        public override void Update(IRawShipTypeInfo raw)
        {
            SortNo = raw.SortNo;
            RepairTimeRatio = raw.RepairTimeRatio;
            BuildOutlineId = raw.BuildOutlineId;
            Name = _unlocalizedName ?? raw.Name;
            UpdateCore(raw);
        }
        partial void UpdateCore(IRawShipTypeInfo raw);
        partial void CreateDummy();

        private readonly BindableSnapshotCollection<EquipmentTypeInfo> availableEquipmentTypes = new BindableSnapshotCollection<EquipmentTypeInfo>();
        public IReadOnlyList<EquipmentTypeInfo> AvailableEquipmentTypes => availableEquipmentTypes;
    }
    public partial class EquipmentTypeInfo : Calculated<IRawEquipmentTypeInfo>
    {
        public EquipmentTypeInfo(int id, ITableProvider owner) : base(id, owner)
        {
            NameTranslation = Module.Localize.GetLocalized("EquipType", id.ToString());
            CreateDummy();
        }

        public string NameTranslation { get; }

        private bool _availableInExtraSlot;
        public bool AvailableInExtraSlot
        {
            get => _availableInExtraSlot;
            internal set => Set(ref _availableInExtraSlot, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            internal set => Set(ref _name, value);
        }

        public override void Update(IRawEquipmentTypeInfo raw)
        {
            AvailableInExtraSlot = raw.AvailableInExtraSlot;
            Name = raw.Name;
            UpdateCore(raw);
        }
        partial void UpdateCore(IRawEquipmentTypeInfo raw);
        partial void CreateDummy();
    }
    public partial class EquipmentInfo : Calculated<IRawEquipmentInfo>
    {
        public EquipmentInfo(int id, ITableProvider owner) : base(id, owner)
        {
            equipmentTypeInfoTable = owner.GetTable<EquipmentTypeInfo>();
            shipInfoTable = owner.GetTable<ShipInfo>();
            NameTranslation = Module.Localize.GetLocalized("EquipName", id.ToString());
            DescriptionTranslation = Module.Localize.GetLocalized("EquipDesc", id.ToString());
            CreateDummy();
        }

        private readonly ITable<EquipmentTypeInfo> equipmentTypeInfoTable;

        private readonly ITable<ShipInfo> shipInfoTable;

        public string NameTranslation { get; }

        public string DescriptionTranslation { get; }

        private EquipmentTypeInfo _type;
        public EquipmentTypeInfo Type
        {
            get => _type;
            internal set => Set(ref _type, value);
        }

        private int _iconId;
        public int IconId
        {
            get => _iconId;
            internal set => Set(ref _iconId, value);
        }

        private int _firepower;
        public int Firepower
        {
            get => _firepower;
            internal set => Set(ref _firepower, value);
        }

        private int _torpedo;
        public int Torpedo
        {
            get => _torpedo;
            internal set => Set(ref _torpedo, value);
        }

        private int _antiAir;
        public int AntiAir
        {
            get => _antiAir;
            internal set => Set(ref _antiAir, value);
        }

        private int _armor;
        public int Armor
        {
            get => _armor;
            internal set => Set(ref _armor, value);
        }

        private int _diveBomberAttack;
        public int DiveBomberAttack
        {
            get => _diveBomberAttack;
            internal set => Set(ref _diveBomberAttack, value);
        }

        private int _antiSubmarine;
        public int AntiSubmarine
        {
            get => _antiSubmarine;
            internal set => Set(ref _antiSubmarine, value);
        }

        private int _accuracy;
        public int Accuracy
        {
            get => _accuracy;
            internal set => Set(ref _accuracy, value);
        }

        private int _evasion;
        public int Evasion
        {
            get => _evasion;
            internal set => Set(ref _evasion, value);
        }

        private int _antiBomber;
        public int AntiBomber
        {
            get => _antiBomber;
            internal set => Set(ref _antiBomber, value);
        }

        private int _interception;
        public int Interception
        {
            get => _interception;
            internal set => Set(ref _interception, value);
        }

        private int _lightOfSight;
        public int LightOfSight
        {
            get => _lightOfSight;
            internal set => Set(ref _lightOfSight, value);
        }

        private FireRange _fireRange;
        public FireRange FireRange
        {
            get => _fireRange;
            internal set => Set(ref _fireRange, value);
        }

        private int _flightRadius;
        public int FlightRadius
        {
            get => _flightRadius;
            internal set => Set(ref _flightRadius, value);
        }

        private Materials _deploymentConsumption;
        public Materials DeploymentConsumption
        {
            get => _deploymentConsumption;
            internal set => Set(ref _deploymentConsumption, value);
        }

        private Materials _dismantleAcquirement;
        public Materials DismantleAcquirement
        {
            get => _dismantleAcquirement;
            internal set => Set(ref _dismantleAcquirement, value);
        }

        private int _rarity;
        public int Rarity
        {
            get => _rarity;
            internal set => Set(ref _rarity, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            internal set => Set(ref _name, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            internal set => Set(ref _description, value);
        }

        public override void Update(IRawEquipmentInfo raw)
        {
            IconId = raw.IconId;
            Firepower = raw.Firepower;
            Torpedo = raw.Torpedo;
            AntiAir = raw.AntiAir;
            Armor = raw.Armor;
            DiveBomberAttack = raw.DiveBomberAttack;
            AntiSubmarine = raw.AntiSubmarine;
            Accuracy = raw.Accuracy;
            Evasion = raw.Evasion;
            AntiBomber = raw.AntiBomber;
            Interception = raw.Interception;
            LightOfSight = raw.LightOfSight;
            FireRange = raw.FireRange;
            FlightRadius = raw.FlightRadius;
            DeploymentConsumption = raw.DeploymentConsumption;
            DismantleAcquirement = raw.DismantleAcquirement;
            Rarity = raw.Rarity;
            Name = raw.Name;
            Description = raw.Description;
            UpdateCore(raw);
        }
        partial void UpdateCore(IRawEquipmentInfo raw);
        partial void CreateDummy();

        private readonly BindableSnapshotCollection<ShipInfo> extraSlotAcceptingShips = new BindableSnapshotCollection<ShipInfo>();
        public IReadOnlyList<ShipInfo> ExtraSlotAcceptingShips => extraSlotAcceptingShips;
    }
    public partial class UseItemInfo : Calculated<IRawUseItem>
    {
        public UseItemInfo(int id, ITableProvider owner) : base(id, owner)
        {
            NameTranslation = Module.Localize.GetLocalized("UseItem", id.ToString());
            CreateDummy();
        }

        public string NameTranslation { get; }

        private string _name;
        public string Name
        {
            get => _name;
            internal set => Set(ref _name, value);
        }

        public override void Update(IRawUseItem raw)
        {
            Name = raw.Name;
            UpdateCore(raw);
        }
        partial void UpdateCore(IRawUseItem raw);
        partial void CreateDummy();
    }
    public partial class MapAreaInfo : Calculated<IRawMapArea>
    {
        public MapAreaInfo(int id, ITableProvider owner) : base(id, owner)
        {
            NameTranslation = Module.Localize.GetLocalized("MapArea", id.ToString());
            CreateDummy();
        }

        public string NameTranslation { get; }

        private bool _isEvent;
        public bool IsEvent
        {
            get => _isEvent;
            internal set => Set(ref _isEvent, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            internal set => Set(ref _name, value);
        }

        public override void Update(IRawMapArea raw)
        {
            IsEvent = raw.IsEvent;
            Name = raw.Name;
            UpdateCore(raw);
        }
        partial void UpdateCore(IRawMapArea raw);
        partial void CreateDummy();
    }
    public partial class MapInfo : Calculated<IRawMapInfo>
    {
        public MapInfo(int id, ITableProvider owner) : base(id, owner)
        {
            mapAreaInfoTable = owner.GetTable<MapAreaInfo>();
            useItemInfoTable = owner.GetTable<UseItemInfo>();
            NameTranslation = Module.Localize.GetLocalized("MapName", id.ToString());
            OperationNameTranslation = Module.Localize.GetLocalized("MapOperation", id.ToString());
            DescriptionTranslation = Module.Localize.GetLocalized("MapDescription", id.ToString());
            CreateDummy();
        }

        private readonly ITable<MapAreaInfo> mapAreaInfoTable;

        private readonly ITable<UseItemInfo> useItemInfoTable;

        public string NameTranslation { get; }

        public string OperationNameTranslation { get; }

        public string DescriptionTranslation { get; }

        private MapAreaInfo _mapArea;
        public MapAreaInfo MapArea
        {
            get => _mapArea;
            internal set => Set(ref _mapArea, value);
        }

        private int _starDifficulty;
        public int StarDifficulty
        {
            get => _starDifficulty;
            internal set => Set(ref _starDifficulty, value);
        }

        private int? _requiredDefeatCount;
        public int? RequiredDefeatCount
        {
            get => _requiredDefeatCount;
            internal set => Set(ref _requiredDefeatCount, value);
        }

        private IReadOnlyCollection<FleetType> _availableFleetTypes;
        public IReadOnlyCollection<FleetType> AvailableFleetTypes
        {
            get => _availableFleetTypes;
            internal set => Set(ref _availableFleetTypes, value);
        }

        private IRawMapBgmInfo _bgmInfo;
        public IRawMapBgmInfo BgmInfo
        {
            get => _bgmInfo;
            internal set => Set(ref _bgmInfo, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            internal set => Set(ref _name, value);
        }

        private string _operationName;
        public string OperationName
        {
            get => _operationName;
            internal set => Set(ref _operationName, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            internal set => Set(ref _description, value);
        }

        public override void Update(IRawMapInfo raw)
        {
            StarDifficulty = raw.StarDifficulty;
            RequiredDefeatCount = raw.RequiredDefeatCount;
            AvailableFleetTypes = raw.AvailableFleetTypes;
            BgmInfo = raw.BgmInfo;
            Name = raw.Name;
            OperationName = raw.OperationName;
            Description = raw.Description;
            UpdateCore(raw);
        }
        partial void UpdateCore(IRawMapInfo raw);
        partial void CreateDummy();

        private readonly BindableSnapshotCollection<UseItemInfo> itemAcquirements = new BindableSnapshotCollection<UseItemInfo>();
        public IReadOnlyList<UseItemInfo> ItemAcquirements => itemAcquirements;
    }
    public partial class ExpeditionInfo : Calculated<IRawExpeditionInfo>
    {
        public ExpeditionInfo(int id, ITableProvider owner) : base(id, owner)
        {
            mapAreaInfoTable = owner.GetTable<MapAreaInfo>();
            NameTranslation = Module.Localize.GetLocalized("ExpeditionName", id.ToString());
            DescriptionTranslation = Module.Localize.GetLocalized("ExpeditionDesc", id.ToString());
            CreateDummy();
        }

        private readonly ITable<MapAreaInfo> mapAreaInfoTable;

        public string NameTranslation { get; }

        public string DescriptionTranslation { get; }

        private string _displayId;
        public string DisplayId
        {
            get => _displayId;
            internal set => Set(ref _displayId, value);
        }

        private MapAreaInfo _mapArea;
        public MapAreaInfo MapArea
        {
            get => _mapArea;
            internal set => Set(ref _mapArea, value);
        }

        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get => _duration;
            internal set => Set(ref _duration, value);
        }

        private int _requiredShipCount;
        public int RequiredShipCount
        {
            get => _requiredShipCount;
            internal set => Set(ref _requiredShipCount, value);
        }

        private int _difficulty;
        public int Difficulty
        {
            get => _difficulty;
            internal set => Set(ref _difficulty, value);
        }

        private double _fuelConsumption;
        public double FuelConsumption
        {
            get => _fuelConsumption;
            internal set => Set(ref _fuelConsumption, value);
        }

        private double _bulletConsumption;
        public double BulletConsumption
        {
            get => _bulletConsumption;
            internal set => Set(ref _bulletConsumption, value);
        }

        private IReadOnlyList<ItemRecord> _rewardItems;
        public IReadOnlyList<ItemRecord> RewardItems
        {
            get => _rewardItems;
            internal set => Set(ref _rewardItems, value);
        }

        private bool _canRecall;
        public bool CanRecall
        {
            get => _canRecall;
            internal set => Set(ref _canRecall, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            internal set => Set(ref _name, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            internal set => Set(ref _description, value);
        }

        public override void Update(IRawExpeditionInfo raw)
        {
            DisplayId = raw.DisplayId;
            Duration = raw.Duration;
            RequiredShipCount = raw.RequiredShipCount;
            Difficulty = raw.Difficulty;
            FuelConsumption = raw.FuelConsumption;
            BulletConsumption = raw.BulletConsumption;
            RewardItems = raw.RewardItems;
            CanRecall = raw.CanRecall;
            Name = raw.Name;
            Description = raw.Description;
            UpdateCore(raw);
        }
        partial void UpdateCore(IRawExpeditionInfo raw);
        partial void CreateDummy();
    }
}
