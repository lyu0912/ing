﻿using System.Collections.Generic;

namespace Sakuno.KanColle.Amatsukaze.Game
{
    public interface ITable<out T> : IReadOnlyCollection<T>, IUpdationSource
    {
        T this[int id] { get; }
    }
}
