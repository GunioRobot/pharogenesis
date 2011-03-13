chooseMoveRectangle
	"Ask the user to designate a new window rectangle."
	| offset p |
	offset _ Sensor anyButtonPressed "Offset if draggin, eg, label"
		ifTrue: [self windowBox topLeft - Sensor cursorPoint]
		ifFalse: [0@0].
	self isCollapsed
		ifTrue: [^ self labelDisplayBox newRectFrom:
					[:f | p _ Sensor cursorPoint + offset.
					p _ (p max: 0@0) truncateTo: 8.
					p extent: f extent]]
		ifFalse: [^ self windowBox newRectFrom:
					[:f | p _ Sensor cursorPoint + offset.
					self constrainFrame: (p extent: f extent)]]