enterHandle: event morph: handle pointName: ptName
	"The mouse has entered reframing mark.  Start a reframe operation."
	| resizer b |
	event anyButtonPressed
		ifTrue: [^ self  "Don't activate resizer if button down"].
	paneMorphs do: [:p | ((p fullBounds insetBy: 1) containsPoint: event cursorPoint)
			ifTrue: [^ self  "Don't activate resizer if in a scrollbar"]].
	resizer _ NewHandleMorph new followHand: event hand
		forEachPointDo:
			[:p | b _ self bounds.
			ptName = #topCenter ifTrue: [self bounds: (b withTop: p y)].
			ptName = #bottomCenter ifTrue: [self bounds: (b withBottom: p y)].
			ptName = #leftCenter ifTrue: [self bounds: (b withLeft: p x)].
			ptName = #rightCenter ifTrue: [self bounds: (b withRight: p x)].
			ptName = #topLeft ifTrue: [self bounds: (b bottomRight rect: p)].
			ptName = #bottomRight ifTrue: [self bounds: (b topLeft rect: p)].
			ptName = #bottomLeft ifTrue: [self bounds: (b topRight rect: p)].
			ptName = #topRight ifTrue: [self bounds: (b bottomLeft rect: p)]]
		lastPointDo: [:lastPoint | ].
	event hand world addMorph: resizer.
	resizer startStepping