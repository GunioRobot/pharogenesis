referentThickness
	^ (self orientation == #horizontal)
		ifTrue:
			[referent height]
		ifFalse:
			[referent width]