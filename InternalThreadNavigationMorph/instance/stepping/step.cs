step

	super step.
	(self valueOfProperty: #previousWorldBounds) = self world bounds ifFalse: [
		self positionAppropriately.
	].
	self class knownThreads
		at: threadName
		ifPresent: [ :known |
			known == listOfPages ifFalse: [
				listOfPages _ known.
				self removeAllMorphs.
				self addButtons.
			].
		].
