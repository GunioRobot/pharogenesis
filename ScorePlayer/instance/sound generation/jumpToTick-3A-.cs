jumpToTick: startTick

	| |
	self reset.
	self processTempoMapAtTick: startTick.
	self skipNoteEventsThruTick: startTick.
	ticksSinceStart _ startTick.
