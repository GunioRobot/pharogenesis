toggleFillsOf: edge
	| depth fillIndex |
	self inline: false.

	(self needAvailableSpace: self stackFillEntryLength * 2) 
		ifFalse:[^nil]. "Make sure we have enough space left"
	depth _ (self edgeZValueOf: edge) << 1.
	fillIndex _ self edgeLeftFillOf: edge.
	fillIndex = 0 ifFalse:[self toggleFill: fillIndex depth: depth rightX: 999999999].
	fillIndex _ self edgeRightFillOf: edge.
	fillIndex = 0 ifFalse:[self toggleFill: fillIndex depth: depth rightX: 999999999].
	self quickRemoveInvalidFillsAt: (self edgeXValueOf: edge).