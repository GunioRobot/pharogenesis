doControl

	| t |
	super doControl.
	1 to: activeSounds size do: [:i | (activeSounds at: i) first doControl].
	ticksSinceStart _ ticksSinceStart + ticksClockIncr.
	t _ ticksSinceStart asInteger.
	self processTempoMapAtTick: t.
	self processEventsAtTick: t.
	done _ self isDone.
