resetTimer
	timeOfMouseDown _ Time millisecondClockValue.
	timeOfLastScroll _ timeOfMouseDown - 1000 max: 0.
	nextPageDirection _ nil.
	currentScrollDelay _ nil