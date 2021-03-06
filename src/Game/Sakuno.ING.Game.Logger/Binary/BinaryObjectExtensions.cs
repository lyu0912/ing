﻿using System.Collections.Generic;
using System.Linq;
using Sakuno.ING.Game.Logger.Entities.Combat;
using Sakuno.ING.Game.Models;
using Sakuno.ING.Game.Models.MasterData;

namespace Sakuno.ING.Game.Logger.Binary
{
    public static class BinaryObjectExtensions
    {
        public static byte[] Store(this IEnumerable<ShipInBattleEntity> fleet)
        {
            if (fleet is null) return null;
            var writer = new BinaryObjectWriter();
            var f = fleet.ToArray();
            writer.WriteArraySize(f.Length);

            static void WriteShipParameter(BinaryObjectWriter w, ShipMordenizationStatus p)
            {
                w.WriteArraySize(2);
                w.WriteInteger(p.Current);
                w.WriteInteger(p.Displaying);
            }

            foreach (var ship in f)
            {
                if (ship is null)
                {
                    writer.WriteNull();
                    continue;
                }
                writer.WriteStartObject();
                writer.WriteJName(1);
                writer.WriteInteger(ship.Id);
                writer.WriteJName(2);
                writer.WriteInteger(ship.Level);
                writer.WriteJName(3);
                WriteShipParameter(writer, ship.Firepower);
                writer.WriteJName(4);
                WriteShipParameter(writer, ship.Torpedo);
                writer.WriteJName(5);
                WriteShipParameter(writer, ship.AntiAir);
                writer.WriteJName(6);
                WriteShipParameter(writer, ship.Armor);
                writer.WriteJName(16);
                WriteShipParameter(writer, ship.Luck);
                writer.WriteJName(17);
                WriteShipParameter(writer, ship.LineOfSight);
                writer.WriteJName(18);
                WriteShipParameter(writer, ship.Evasion);
                writer.WriteJName(19);
                WriteShipParameter(writer, ship.AntiSubmarine);
                if (ship.Fuel is ClampedValue fuel)
                {
                    writer.WriteJName(14);
                    writer.WriteArraySize(2);
                    writer.WriteInteger(fuel.Current);
                    writer.WriteInteger(fuel.Max);
                }
                if (ship.Bullet is ClampedValue bullet)
                {
                    writer.WriteJName(15);
                    writer.WriteArraySize(2);
                    writer.WriteInteger(bullet.Current);
                    writer.WriteInteger(bullet.Max);
                }
                if (ship.Slots != null)
                {
                    writer.WriteJName(7);
                    writer.WriteArraySize(ship.Slots.Length);
                    foreach (var e in ship.Slots)
                        WriteSlot(writer, e);
                }
                if (ship.ExtraSlot.Id > 0)
                {
                    writer.WriteJName(8);
                    WriteSlot(writer, ship.ExtraSlot);
                }
                writer.WriteEndObject();
            }
            return writer.Complete();
        }

        public static ShipInBattleEntity[] ParseFleet(byte[] data)
        {
            if (data is null) return null;
            var reader = new BinaryObjectReader(data);
            if (!reader.IsNextArray())
                return null;
            var result = new ShipInBattleEntity[reader.ReadContainerLength()];

            static ShipMordenizationStatus ReadShipParameter(BinaryObjectReader r)
            {
                (int v, int d) = ReadArray2(r);
                return new ShipMordenizationStatus(v, d);
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (!reader.StartObjectOrSkip())
                    continue;
                var ship = new ShipInBattleEntity();
                while (reader.TryReadJName(out int jName))
                    switch (jName)
                    {
                        case 1:
                            ship.Id = (ShipInfoId)(reader.ReadIntegerOrSkip() ?? 0);
                            break;
                        case 2:
                            ship.Level = reader.ReadIntegerOrSkip() ?? 0;
                            break;
                        case 3:
                            ship.Firepower = ReadShipParameter(reader);
                            break;
                        case 4:
                            ship.Torpedo = ReadShipParameter(reader);
                            break;
                        case 5:
                            ship.AntiAir = ReadShipParameter(reader);
                            break;
                        case 6:
                            ship.Armor = ReadShipParameter(reader);
                            break;
                        case 14:
                            ship.Fuel = ReadArray2(reader);
                            break;
                        case 15:
                            ship.Bullet = ReadArray2(reader);
                            break;
                        case 16:
                            ship.Luck = ReadShipParameter(reader);
                            break;
                        case 17:
                            ship.LineOfSight = ReadShipParameter(reader);
                            break;
                        case 18:
                            ship.Evasion = ReadShipParameter(reader);
                            break;
                        case 19:
                            ship.AntiSubmarine = ReadShipParameter(reader);
                            break;
                        case 7:
                            if (reader.TryReadContainerLengthOrSkip(out int l))
                            {
                                ship.Slots = new SlotInBattleEntity[l];
                                for (int j = 0; j < l; j++)
                                    ship.Slots[j] = TryReadSlot(ref reader);
                            }
                            break;
                        case 8:
                            ship.ExtraSlot = TryReadSlot(ref reader);
                            break;
                        default:
                            reader.SkipValue();
                            break;
                    }
                result[i] = ship;
            }
            return result;
        }

        private static (int, int) ReadArray2(BinaryObjectReader r)
        {
            if (r.TryReadContainerLengthOrSkip(out int l))
                if (l == 2)
                {
                    int a = r.ReadIntegerOrSkip() ?? 0;
                    int b = r.ReadIntegerOrSkip() ?? 0;
                    return (a, b);
                }
                else while (l-- > 0)
                        r.SkipValue();
            return default;
        }

        public static byte[] Store(this IEnumerable<AirForceInBattle> groups)
        {
            if (groups is null) return null;
            var writer = new BinaryObjectWriter();
            var g = groups.ToArray();
            writer.WriteArraySize(g.Length);
            foreach (var group in g)
            {
                writer.WriteStartObject();
                writer.WriteJName(1);
                writer.WriteInteger(group.Id);
                writer.WriteJName(2);
                writer.WriteArraySize(group.Squadrons.Count);
                foreach (var e in group.Squadrons)
                    WriteSlot(writer, e);
                writer.WriteEndObject();
            }
            return writer.Complete();
        }

        public static AirForceInBattle[] ParseAirForce(byte[] data)
        {
            if (data is null) return null;
            var reader = new BinaryObjectReader(data);
            if (!reader.TryReadContainerLengthOrSkip(out int l))
                return null;
            var result = new AirForceInBattle[l];
            for (int i = 0; i < l; i++)
            {
                if (!reader.StartObjectOrSkip())
                    continue;
                var group = new AirForceInBattle();
                while (reader.TryReadJName(out int jName))
                    switch (jName)
                    {
                        case 1:
                            group.Id = (AirForceGroupId)(reader.ReadIntegerOrSkip() ?? 0);
                            break;
                        case 2:
                            if (reader.TryReadContainerLengthOrSkip(out int l2))
                            {
                                var squadrons = new SlotInBattleEntity[l2];
                                for (int j = 0; j < l2; j++)
                                    squadrons[j] = TryReadSlot(ref reader);
                                group.Squadrons = squadrons;
                            }
                            break;
                    }
                result[i] = group;
            }
            return result;
        }

        private static void WriteSlot(BinaryObjectWriter w, in SlotInBattleEntity slot)
        {
            w.WriteStartObject();
            w.WriteJName(9);
            w.WriteInteger(slot.Id);
            w.WriteJName(12);
            if (slot.Count != default)
            {
                w.WriteArraySize(2);
                w.WriteInteger(slot.Count.Current);
                w.WriteInteger(slot.Count.Max);
            }
            if (slot.ImprovementLevel > 0)
            {
                w.WriteJName(10);
                w.WriteInteger(slot.ImprovementLevel);
            }
            if (slot.AirProficiency > 0)
            {
                w.WriteJName(11);
                w.WriteInteger(slot.AirProficiency);
            }
            w.WriteEndObject();
        }

        private static SlotInBattleEntity TryReadSlot(ref BinaryObjectReader r)
        {
            if (!r.StartObjectOrSkip())
                return default;
            var e = new SlotInBattleEntity();
            while (r.TryReadJName(out int jName))
                switch (jName)
                {
                    case 9:
                        e.Id = (EquipmentInfoId)(r.ReadIntegerOrSkip() ?? 0);
                        break;
                    case 10:
                        e.ImprovementLevel = r.ReadIntegerOrSkip() ?? 0;
                        break;
                    case 11:
                        e.AirProficiency = r.ReadIntegerOrSkip() ?? 0;
                        break;
                    case 12:
                        e.Count = ReadArray2(r);
                        break;
                }
            return e;
        }
    }
}
