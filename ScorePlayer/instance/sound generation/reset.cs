reset

	super reset.
	tempo _ 120.0.
	self tempoOrRateChanged.
	done _ false.
	ticksSinceStart _ 0.
	trackEventIndex _ Array new: score tracks size withAll: 1.
	tempoMapIndex _ 1.
	activeSounds _ OrderedCollection new.
