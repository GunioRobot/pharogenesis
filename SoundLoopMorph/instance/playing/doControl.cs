doControl

	seqSound doControl.
	controlIndex _ controlIndex + 1.
	controlIndex >= (self controlRate * (self innerBounds width // 128))
		ifTrue: [controlIndex _ 0].
