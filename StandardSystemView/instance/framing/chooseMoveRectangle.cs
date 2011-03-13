chooseMoveRectangle
	"Ask the user to designate a new window rectangle."
	| offset p |
	offset := Sensor anyButtonPressed "Offset if draggin, eg, label"
		ifTrue: [self windowBox topLeft - Sensor cursorPoint]
		ifFalse: [0@0].
	self isCollapsed
		ifTrue: [^ self labelDisplayBox newRectFrom:
					[:f | p := Sensor cursorPoint + offset.
					p := (p max: 0@0) truncateTo: 8.
					p extent: f extent]]
		ifFalse: [^ self windowBox newRectFrom:
					[:f | p := Sensor cursorPoint + offset.
					self constrainFrame: (p extent: f extent)]]