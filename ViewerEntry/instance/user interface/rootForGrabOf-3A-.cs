rootForGrabOf: aMorph
	^ aMorph == self
		ifTrue: [nil]
		ifFalse:	[super rootForGrabOf: aMorph]