restoreAfter: aBlock
	"Evaluate the block, wait for a mouse click, and then restore the screen."

	aBlock value.
	Sensor waitButton.
	Smalltalk isMorphic
		ifTrue: [World fullRepaintNeeded]
		ifFalse: [(ScheduledControllers restore; activeController) view emphasize]