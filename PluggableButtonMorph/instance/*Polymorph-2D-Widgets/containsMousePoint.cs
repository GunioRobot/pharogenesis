containsMousePoint
	"Answer whether the mouse is in the receiver and our window is active.
	Not ideal, but no easy way of determining if a mouse over would be sent
	to the receiver."
	
	|w|
	w := self ownerThatIsA: SystemWindow.
	(w notNil and: [w isActive not]) ifTrue: [^false].
	^self containsPoint: (self globalPointToLocal: Sensor peekMousePt)