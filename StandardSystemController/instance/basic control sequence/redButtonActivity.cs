redButtonActivity
	"If cursor is in label of a window when red button is pushed,
	check for closeBox or growBox, else drag the window frame"
	| box p |
	p _ sensor cursorPoint.
	self labelHasCursor ifFalse: [super redButtonActivity. ^ self].
	sensor blueButtonPressed & self viewHasCursor 
		ifTrue: [^ self blueButtonActivity].
	((box _ view closeBoxFrame) containsPoint: p)
		ifTrue: [Utilities awaitMouseUpIn: box repeating: [] ifSucceed: [self close. ^ self].
				^ self].
	((box _ view growBoxFrame) containsPoint: p)
		ifTrue: [Utilities awaitMouseUpIn: box repeating: [] ifSucceed:
					[Sensor controlKeyPressed ifTrue:
						[^ self expand; fullScreen].
					^ view isCollapsed
						ifTrue: [self expand]
						ifFalse: [self collapse]].
				^ self].
	((box _ view labelTextRegion expandBy: 1) containsPoint: p)
		ifTrue: [Utilities awaitMouseUpIn: box repeating: [] ifSucceed:
					[^ self label].
				^ self].
	self move.
