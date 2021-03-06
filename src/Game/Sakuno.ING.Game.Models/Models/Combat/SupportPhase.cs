﻿using System;

namespace Sakuno.ING.Game.Models.Combat
{
    public class SupportPhase : BattlePhase
    {
        private readonly struct Builder : IBattlePhaseBuilder
        {
            private readonly Side enemy;
            private readonly AttackType type;

            public Builder(Side enemy, AttackType type)
            {
                this.enemy = enemy;
                this.type = type;
            }

            public BattleParticipant MapShip(int index, bool isEnemy)
                => (isEnemy ? enemy : throw new InvalidOperationException()).FindShip(index);

            public AttackType MapType(int rawType) => type;
        }

        public SupportPhase(SupportFireType type, MasterDataRoot masterData, Side enemy, RawSupportPhase raw)
            : base(Initialze(masterData, raw, new Builder(enemy, MapTypeStatic(type))))
        {
            Type = type;
        }


        public SupportPhase(SupportFireType type, MasterDataRoot masterData, Side enemy, RawAerialPhase raw)
            : base(Initialze(masterData, raw, new Builder(enemy, MapTypeStatic(type))))
        {
            Type = type;
            AerialAlly = new AerialSide(masterData, raw.Ally, null);
            AerialEnemy = new AerialSide(masterData, raw.Enemy, enemy);
            AerialFightingResult = raw.FightingResult;
        }

        private static AttackType MapTypeStatic(SupportFireType type) => type switch
        {
            SupportFireType.Shelling => AttackType.SupportShelling,
            SupportFireType.Torpedo => AttackType.SupportTorpedo,
            SupportFireType.Aerial => AttackType.SupportAerial,
            SupportFireType.AntiSubmarine => AttackType.SupportAerial,
            _ => AttackType.Unknown
        };

        public SupportFireType Type { get; }
        public AerialSide AerialAlly { get; }
        public AerialSide AerialEnemy { get; }
        public AirFightingResult? AerialFightingResult { get; }
    }
}
