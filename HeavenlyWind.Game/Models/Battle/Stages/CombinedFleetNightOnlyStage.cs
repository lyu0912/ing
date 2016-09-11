﻿using Sakuno.KanColle.Amatsukaze.Game.Models.Battle.Phases;
using Sakuno.KanColle.Amatsukaze.Game.Models.Raw.Battle;
using Sakuno.KanColle.Amatsukaze.Game.Parsers;

namespace Sakuno.KanColle.Amatsukaze.Game.Models.Battle.Stages
{
    class CombinedFleetNightOnlyStage : CombinedFleetNight
    {
        internal protected CombinedFleetNightOnlyStage(BattleInfo rpOwner, ApiInfo rpInfo) : base(rpOwner)
        {
            var rRawData = rpInfo.Data as RawCombinedFleetNightOnly;

            Shelling = new ShellingPhase(this, rRawData.Shelling, true);
        }
    }
}
