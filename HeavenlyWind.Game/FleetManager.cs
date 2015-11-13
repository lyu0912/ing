﻿using Sakuno.KanColle.Amatsukaze.Game.Models;
using Sakuno.KanColle.Amatsukaze.Game.Models.Raw;
using Sakuno.KanColle.Amatsukaze.Game.Services;
using System;
using System.Collections.Generic;

namespace Sakuno.KanColle.Amatsukaze.Game
{
    public class FleetManager : ModelBase
    {
        public IDTable<Fleet> Table { get; } = new IDTable<Fleet>();

        public CombinedFleetType CombinedFleetType { get; internal set; }

        public Fleet this[int rpID] => Table[rpID];

        public event Action<IEnumerable<Fleet>> FleetsUpdated = delegate { };

        internal FleetManager()
        {
            SessionService.Instance.Subscribe("api_req_hensei/change", r =>
            {
                var rFleet = Table[int.Parse(r.Requests["api_id"])];

                var rIndex = int.Parse(r.Requests["api_ship_idx"]);
                if (rIndex == -1)
                {
                    rFleet.RemoveAllExceptFlagship();
                    rFleet.Update();
                    return;
                }

                var rShipID = int.Parse(r.Requests["api_ship_id"]);
                if (rShipID == -1)
                {
                    rFleet.Remove(rIndex);
                    rFleet.Update();
                    return;
                }

                var rShip = KanColleGame.Current.Port.Ships[rShipID];
                var rOriginalFleet = rShip.OwnerFleet;
                var rOriginalIndex = rOriginalFleet?.Ships.IndexOf(rShip);

                var rOriginalShip = rFleet.Organize(rIndex, rShip);
                if (rOriginalIndex.HasValue)
                    rOriginalFleet.Organize(rOriginalIndex.Value, rOriginalShip);

                rFleet.Update();
            });

            SessionService.Instance.Subscribe("api_get_member/deck", r => Update(r.GetData<RawFleet[]>()));
            SessionService.Instance.Subscribe("api_req_hensei/preset_select", r =>
            {
                var rFleet = Table[int.Parse(r.Requests["api_deck_id"])];
                rFleet.Update(r.GetData<RawFleet>());
            });
        }

        internal void Update(RawPort rpPort)
        {
            CombinedFleetType = rpPort.CombinedFleetType;

            Update(rpPort.Fleets);
        }
        internal void Update(RawFleet[] rpFleets)
        {
            if (Table.UpdateRawData(rpFleets, r => new Fleet(KanColleGame.Current.Port, r), (rpData, rpRawData) => rpData.Update(rpRawData)))
                FleetsUpdated(Table.Values);
        }
    }
}
