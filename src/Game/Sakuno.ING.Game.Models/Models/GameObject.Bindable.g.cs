//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel;

namespace Sakuno.ING.Game.Models
{
    partial class Slot
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly PropertyChangedEventArgs __eventArgs_aircraft = new PropertyChangedEventArgs(nameof(Aircraft));
        [EditorBrowsable(EditorBrowsableState.Never)]
        private ClampedValue _aircraft;
        public ClampedValue Aircraft
        {
            get => _aircraft;
            internal set => Set(ref _aircraft, value, __eventArgs_aircraft);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly PropertyChangedEventArgs __eventArgs_airFightPower = new PropertyChangedEventArgs(nameof(AirFightPower));
        [EditorBrowsable(EditorBrowsableState.Never)]
        private AirFightPower _airFightPower;
        public AirFightPower AirFightPower
        {
            get => _airFightPower;
            private set => Set(ref _airFightPower, value, __eventArgs_airFightPower);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly PropertyChangedEventArgs __eventArgs_effectiveLoS = new PropertyChangedEventArgs(nameof(EffectiveLoS));
        [EditorBrowsable(EditorBrowsableState.Never)]
        private double _effectiveLoS;
        public double EffectiveLoS
        {
            get => _effectiveLoS;
            private set => Set(ref _effectiveLoS, value, __eventArgs_effectiveLoS);
        }
    }
    partial class HomeportEquipment
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly PropertyChangedEventArgs __eventArgs_slot = new PropertyChangedEventArgs(nameof(Slot));
        [EditorBrowsable(EditorBrowsableState.Never)]
        private HomeportSlot _slot;
        public HomeportSlot Slot
        {
            get => _slot;
            internal set => Set(ref _slot, value, __eventArgs_slot);
        }
    }
    partial class HomeportShip
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly PropertyChangedEventArgs __eventArgs_fleet = new PropertyChangedEventArgs(nameof(Fleet));
        [EditorBrowsable(EditorBrowsableState.Never)]
        private HomeportFleet _fleet;
        public HomeportFleet Fleet
        {
            get => _fleet;
            internal set => Set(ref _fleet, value, __eventArgs_fleet);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly PropertyChangedEventArgs __eventArgs_isRepairing = new PropertyChangedEventArgs(nameof(IsRepairing));
        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool _isRepairing;
        public bool IsRepairing
        {
            get => _isRepairing;
            internal set => Set(ref _isRepairing, value, __eventArgs_isRepairing);
        }
    }
}
