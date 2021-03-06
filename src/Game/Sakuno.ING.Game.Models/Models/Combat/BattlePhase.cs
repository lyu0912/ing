﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Sakuno.ING.Game.Models.Combat
{
    public abstract class BattlePhase
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BattlePhase This => this;

        public int Index { get; }
        public IReadOnlyList<Attack> Attacks { get; }
        protected BattlePhase(IEnumerable<Attack> attacks, int index = 0)
        {
            Index = index;
            Attacks = attacks.ToArray();
        }

        protected static IEnumerable<Attack> Initialze<TBuilder>(MasterDataRoot masterData, RawBattlePhase raw, TBuilder builder)
            where TBuilder : IBattlePhaseBuilder
            => from attack in raw.Attacks
               let source = attack.SourceIndex is int s ? builder.MapShip(s, attack.EnemyAttacks) : null
               select new Attack(source,
                   builder.MapType(attack.Type),
                   masterData.EquipmentInfos[attack.EquipmentUsed],
                   from hit in attack.Hits
                   select new Hit(source, builder.MapShip(hit.TargetIndex, !attack.EnemyAttacks), hit));
    }
}
