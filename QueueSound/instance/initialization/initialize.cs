initialize
	super initialize.
	sounds _ SharedQueue new.
	done _ false.
	startTime _ Time millisecondClockValue