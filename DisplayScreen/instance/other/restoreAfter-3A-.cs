restoreAfter: aBlock
	"Evaluate the block, wait for a mouse click, and then restore the screen."

	aBlock value.
	Sensor waitButton.
	Smalltalk isMorphic
		ifTrue: [self repaintMorphicDisplay]
		ifFalse: [(ScheduledControllers restore; activeController) view emphasize]