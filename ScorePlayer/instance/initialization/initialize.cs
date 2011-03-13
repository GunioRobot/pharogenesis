initialize

	super initialize.
	score _ MIDIScore new initialize.
	instruments _ Array new.
	leftVols _ Array new.
	rightVols _ Array new.
	muted _ Array new.
	rate _ 1.0.
	repeat _ false.
