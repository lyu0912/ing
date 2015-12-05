﻿using Sakuno.KanColle.Amatsukaze.Game.Models;
using Sakuno.KanColle.Amatsukaze.Game.Parsers;
using System;
using System.Data.SQLite;

namespace Sakuno.KanColle.Amatsukaze.Game.Services.Records
{
    public class BattleRecord : RecordBase
    {
        public override string GroupName => "battle";

        internal BattleRecord(SQLiteConnection rpConnection) : base(rpConnection)
        {
            DisposableObjects.Add(SessionService.Instance.Subscribe("api_req_sortie/battle", Process));
            DisposableObjects.Add(SessionService.Instance.Subscribe("api_req_battle_midnight/battle", Process));
            DisposableObjects.Add(SessionService.Instance.Subscribe("api_req_battle_midnight/sp_midnight", Process));
            DisposableObjects.Add(SessionService.Instance.Subscribe("api_req_sortie/airbattle", Process));
            DisposableObjects.Add(SessionService.Instance.Subscribe("api_req_combined_battle/battle", Process));
            DisposableObjects.Add(SessionService.Instance.Subscribe("api_req_combined_battle/battle_water", Process));
            DisposableObjects.Add(SessionService.Instance.Subscribe("api_req_combined_battle/airbattle", Process));
            DisposableObjects.Add(SessionService.Instance.Subscribe("api_req_combined_battle/midnight_battle", Process));
            DisposableObjects.Add(SessionService.Instance.Subscribe("api_req_combined_battle/sp_midnight", Process));
        }


        protected override void CreateTable()
        {
            using (var rCommand = Connection.CreateCommand())
            {
                rCommand.CommandText = "CREATE TABLE IF NOT EXISTS battle_count(" +
                    "map INTEGER NOT NULL, " +
                    "cell INTEGER NOT NULL, " +
                    "count INTEGER NOT NULL DEFAULT 0, " +
                    "CONSTRAINT [] PRIMARY KEY(map, cell)) WITHOUT ROWID;";

                rCommand.ExecuteNonQuery();
            }
        }

        void Process(ApiData rpData)
        {
            if (rpData.Api != "api_req_battle_midnight/battle" && rpData.Api != "api_req_combined_battle/midnight_battle")
                UpdateCount();
        }
        void UpdateCount()
        {
            var rSortieInfo = KanColleGame.Current.Sortie;
            var rMap = rSortieInfo.Map.ID;
            var rCell = rSortieInfo.Cell.InternalID;

            using (var rCommand = Connection.CreateCommand())
            {
                rCommand.CommandText = "INSERT OR IGNORE INTO battle_count(map, cell) VALUES (@map, @cell);" +
                    "UPDATE battle_count SET count = count + 1 WHERE map = @map AND cell = @cell;";
                rCommand.Parameters.AddWithValue("@map", rMap);
                rCommand.Parameters.AddWithValue("@cell", rCell);

                rCommand.ExecuteNonQuery();
            }
        }

    }
}