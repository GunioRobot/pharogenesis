waitForDelay1: delay1 delay2: delay2
	"Return true if an appropriate delay has passed since the last scroll operation.
	The delay decreases exponentially from delay1 to delay2."
	| now scrollDelay |
	timeOfLastScroll == nil ifTrue: [self resetTimer]. "Only needed for old instances"
	now _ Time millisecondClockValue.
	now < timeOfLastScroll ifTrue: [self resetTimer  "rare clock rollover"].
	(scrollDelay _ currentScrollDelay) == nil ifTrue: [scrollDelay _ delay1  "initial delay"].
	now > (timeOfLastScroll + scrollDelay) ifFalse: [^ false  "not time yet"].
	currentScrollDelay _ scrollDelay*9//10 max: delay2.  "decrease the delay"
	timeOfLastScroll _ now.
	^ true