redButtonActivity
	"If cursor is in label of a window when red button is pushed,
	check for closeBox or growBox, else drag the window frame
	or edit the label."

	| box p |
	p := sensor cursorPoint.
	self labelHasCursor ifFalse: [super redButtonActivity. ^ self].
	((box := view closeBoxFrame) containsPoint: p)
		ifTrue:
			[Utilities
				awaitMouseUpIn: box
				repeating: []
				ifSucceed: [self close. ^ self].
			^ self].
	((box := view growBoxFrame) containsPoint: p)
		ifTrue:
			[Utilities
				awaitMouseUpIn: box
				repeating: []
				ifSucceed:
					[Sensor controlKeyPressed ifTrue: [^ self expand; fullScreen].
					^ view isCollapsed
						ifTrue: [self expand]
						ifFalse: [self collapse]].
			^ self].
	(((box := view labelTextRegion expandBy: 1) containsPoint: p)
			and: [Preferences clickOnLabelToEdit or: [sensor leftShiftDown]])
		ifTrue:
			[Utilities
				awaitMouseUpIn: box
				repeating: []
				ifSucceed: [^ self label].
			^ self].
	self move