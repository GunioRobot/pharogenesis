tempoOrRateChanged

	secsPerTick _ 60.0 / (tempo * rate * score ticksPerQuarterNote).
	ticksClockIncr _ (1.0 / self controlRate) / secsPerTick.
