canLinkTo: tMeth
	"Apply a simply heuristic to determine if it's worth linking to this method."
	self inline: true.

	(UseInlineCacheDelay and: [newInlineCacheDelay = 0])
		ifTrue: [^true].
	^(self fetchPointer: MethodPrimIndex ofObject: tMeth) ~= ConstZero		"method has a primitive response"
		or: [(((self sizeBitsOf: tMeth) "bytes"
					- (MethodOpcodeStart * 4 "bytes per header word") - BaseHeaderSize)
					// 8 "translated bytes per bytecode")
				< inlineCacheLimit]