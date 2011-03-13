mouseSelect
	"Answer with an Array of two CharacterBlocks that represent the text 
	selection that the user makes.  Return quickly if the button is noticed up
	to make double-click more responsive."

	| pivotBlock startBlock stopBlock origPoint stillDown |
	stillDown := Sensor redButtonPressed.
	pivotBlock := startBlock := stopBlock :=
		self characterBlockAtPoint: (origPoint := Sensor cursorPoint).
	stillDown := stillDown and: [Sensor redButtonPressed].
	self reverseFrom: startBlock to: startBlock.
	[stillDown and: [Sensor cursorPoint = origPoint]] whileTrue:
		[stillDown := Sensor redButtonPressed].
	(stillDown and: [clippingRectangle containsPoint: Sensor cursorPoint])
		ifFalse: [^Array with: pivotBlock with: stopBlock].
	^ self mouseMovedFrom: startBlock 
		pivotBlock: pivotBlock
		showingCaret: true