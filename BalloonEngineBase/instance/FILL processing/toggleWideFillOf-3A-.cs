toggleWideFillOf: edge
	| fill type lineWidth depth rightX index |
	self inline: false.
	type _ self edgeTypeOf: edge.
	dispatchedValue _ edge.
	self dispatchOn: type in: WideLineWidthTable.
	lineWidth _ dispatchReturnValue.
	self dispatchOn: type in: WideLineFillTable.
	fill _ dispatchReturnValue.
	fill = 0 ifTrue:[^nil].
	(self needAvailableSpace: self stackFillEntryLength) 
		ifFalse:[^nil]. "Make sure we have enough space left"
	depth _ (self edgeZValueOf: edge) << 1 + 1. "So lines sort before interior fills"
	rightX _ (self edgeXValueOf: edge) + lineWidth.
	index _ self findStackFill: fill depth: depth.
	index = -1 ifTrue:[
		self showFill: fill 
			depth: depth
			rightX: rightX.
	] ifFalse:[
		(self stackFillRightX: index) < rightX
			ifTrue:[self stackFillRightX: index put: rightX].
	].
	self quickRemoveInvalidFillsAt: (self edgeXValueOf: edge).