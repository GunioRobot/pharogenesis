tempoOrRateChanged
	"This method should be called after changing the tempo or rate."

	secsPerTick _ 60.0 / (tempo * rate * score ticksPerQuarterNote).
	ticksClockIncr _ (1.0 / self controlRate) / secsPerTick.
