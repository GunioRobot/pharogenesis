eyedropper: aButton action: aSelector cursor: aCursor
	"Take total control and pick up a color!!"

	| pt feedbackColor |
	aButton state: #on.
	tool ifNotNil: [tool state: #off].
	currentCursor _ aCursor.
"	self world hands first showTemporaryCursor: aCursor 
		hotSpotOffset: (aCursor ifNil: [0@0] ifNotNil: [aCursor offset])."
	feedbackColor _ Display colorAt: Sensor cursorPoint.
	self addMorphFront: colorMemory.	"Full color picker"
	self world displayWorld.
		[Sensor anyButtonPressed] whileFalse: [
			pt _ Sensor cursorPoint.
			feedbackColor _ Display colorAt: pt.
			Display fill: (colorPatch bounds translateBy: self world viewBox origin) 
					fillColor: feedbackColor].
		Sensor waitNoButton.
"	self world hands first showTemporaryCursor: nil 
		hotSpotOffset: 0@0."
	self currentColor: feedbackColor.
	colorMemory delete.
	tool ifNotNil: [tool state: #on.
		currentCursor _ tool arguments at: 3].
	aButton state: #off.