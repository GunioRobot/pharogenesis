mouseSelect
	"Answer with an Array of two CharacterBlocks that represent the text 
	selection that the user makes.  Return quickly if the button is noticed up
	to make double-click more responsive."

	| pivotBlock startBlock stopBlock origPoint stillDown |
	stillDown _ Sensor redButtonPressed.
	pivotBlock _ startBlock _ stopBlock _
		self characterBlockAtPoint: (origPoint _ Sensor cursorPoint).
	stillDown _ stillDown and: [Sensor redButtonPressed].
	self reverseFrom: startBlock to: startBlock.
	[stillDown and: [Sensor cursorPoint = origPoint]] whileTrue:
		[stillDown _ Sensor redButtonPressed].
	(stillDown and: [clippingRectangle containsPoint: Sensor cursorPoint])
		ifFalse: [^Array with: pivotBlock with: stopBlock].
	^ self mouseMovedFrom: startBlock 
		pivotBlock: pivotBlock
		showingCaret: true