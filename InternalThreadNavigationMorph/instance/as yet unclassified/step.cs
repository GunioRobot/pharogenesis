step

	super step.
	self class knownThreads
		at: threadName
		ifPresent: [ :known |
			known == listOfPages ifFalse: [
				listOfPages _ known.
				self removeAllMorphs.
				self addButtons.
			].
		].
