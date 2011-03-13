eyedropper: aButton action: aSelector cursor: aCursor evt: evt 
	"Take total control and pick up a color!!"
	| pt feedbackColor |
	aButton state: #on.
	tool
		ifNotNil: [tool state: #off].
	currentCursor _ aCursor.
	evt hand showTemporaryCursor: currentCursor hotSpotOffset: 6 negated @ 4 negated.
	"<<<< the form was changed a bit??"
	feedbackColor _ Display colorAt: Sensor cursorPoint.
	colorMemory align: colorMemory bounds topRight with: colorMemoryThin bounds topRight.
	self addMorphFront: colorMemory.
	"Full color picker"
	[Sensor anyButtonPressed]
		whileFalse: [pt _ Sensor cursorPoint.
			"deal with the fact that 32 bit displays may have garbage in the 
			alpha bits"
			feedbackColor _ Display depth = 32
						ifTrue: [Color
								colorFromPixelValue: ((Display pixelValueAt: pt)
										bitOr: 4278190080)
								depth: 32]
						ifFalse: [Display colorAt: pt].
			"the hand needs to be drawn"
			evt hand position: pt.
			self world displayWorldSafely].
	Sensor waitNoButton.
	evt hand showTemporaryCursor: nil hotSpotOffset: 0 @ 0.
	self currentColor: feedbackColor evt: evt.
	colorMemory delete.
	tool
		ifNotNil: [tool state: #on.
			currentCursor _ tool arguments at: 3].
	aButton state: #off