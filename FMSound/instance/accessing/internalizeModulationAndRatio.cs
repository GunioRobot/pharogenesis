internalizeModulationAndRatio
	"Recompute the internal state for the modulation index and frequency ratio relative to the current pitch."

	modulation < 0.0 ifTrue: [modulation _ modulation negated].
	multiplier < 0.0 ifTrue: [multiplier _ multiplier negated].
	normalizedModulation _
		((modulation * scaledIndexIncr)  / ScaleFactor) asInteger.
	scaledOffsetIndexIncr _ (multiplier * scaledIndexIncr) asInteger.

	"clip to maximum values if necessary"
	normalizedModulation > MaxScaledValue ifTrue: [
		normalizedModulation _ MaxScaledValue.
		modulation _ (normalizedModulation * ScaleFactor) asFloat / scaledIndexIncr].
	scaledOffsetIndexIncr > (scaledWaveTableSize // 2) ifTrue: [
		scaledOffsetIndexIncr _ scaledWaveTableSize // 2.
		multiplier _ scaledOffsetIndexIncr asFloat / scaledIndexIncr].
