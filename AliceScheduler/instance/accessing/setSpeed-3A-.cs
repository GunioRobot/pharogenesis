setSpeed: newSpeed
	"This method sets the speed for the Scheduler. 1 is a 1:1 mapping with clock time, 2 is a 2:1 mapping, etc."

	(speed > 0) ifTrue: [speed _ newSpeed] ifFalse: [self error: 'Scheduler speed must be greater than 0.'].

