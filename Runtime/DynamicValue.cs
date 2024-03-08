using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;

namespace NativeColorScheme {
	[Serializable]
	public struct DynamicValue<Value> : IEquatable<DynamicValue<Value>>, IEquatable<Value> {
		public Value light;
		public Value dark;

		// MARK: - Lifecycle

		public DynamicValue(in Value light, in Value dark) {
			this.light = light;
			this.dark = dark;
		}

		// MARK: - Operators

		[MethodImpl(AggressiveInlining)]
		public static implicit operator Value(in DynamicValue<Value> value)
			=> value.GetCurrent();

		[MethodImpl(AggressiveInlining)]
		public static implicit operator DynamicValue<Value>(in Value value)
			=> new DynamicValue<Value>(value, value);

		[MethodImpl(AggressiveInlining)]
		public static bool operator ==(Value lhs, DynamicValue<Value> rhs)
			=> lhs.Equals(rhs);

		[MethodImpl(AggressiveInlining)]
		public static bool operator !=(Value lhs, DynamicValue<Value> rhs)
			=> !lhs.Equals(rhs);

		// MARK: - IEquatable

		[MethodImpl(AggressiveInlining)]
		public readonly bool Equals(DynamicValue<Value> other)
			=> other.light.Equals(light) && other.dark.Equals(dark);

		[MethodImpl(AggressiveInlining)]
		public readonly bool Equals(Value other)
			=> other.Equals(GetCurrent());

		// MARK: - Override

		[MethodImpl(AggressiveInlining)]
		public readonly override bool Equals(object obj) => obj switch {
			DynamicValue<Value> other => this.Equals(other),
			Value other => this.Equals(other),
			_ => throw new ArgumentException()
		};

		[MethodImpl(AggressiveInlining)]
		public readonly override int GetHashCode()
			=> (light, dark).GetHashCode();

		// MARK: -

		[MethodImpl(AggressiveInlining)]
		public readonly Value GetCurrent() => ColorSchemeUtil.Current switch {
			ColorScheme.Dark => dark,
			_ => light
		};
	}
}