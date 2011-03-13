yellowButtonActivity
	"Determine which item in the yellow button pop-up menu is selected. If 
	one is selected, then send the corresponding message to the object 
	designated as the menu message receiver.
	1/18/96 sw: added the escape to shifted variant
	1/24/96 sw: separate methods for shifted and unshifted variant.
	1/25/96 sw: speeded up by passing shifted menu along"

	| shiftMenu |
	^ (Sensor leftShiftDown and: [(shiftMenu _ self shiftedYellowButtonMenu) notNil])
		ifTrue: [self shiftedYellowButtonActivity: shiftMenu]
		ifFalse:	[self unshiftedYellowButtonActivity]