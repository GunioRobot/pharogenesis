extendedStoreBytecode
	| descriptor variableType variableIndex association |
	self inline: true.
	descriptor _ self fetchByte.
	self fetchNextBytecode.
	variableType _ descriptor >> 6 bitAnd: 3.
	variableIndex _ descriptor bitAnd: 63.
	variableType = 0
		ifTrue: [^ self storePointer: variableIndex ofObject: receiver withValue: self internalStackTop].
	variableType = 1
		ifTrue: [^ self storePointerUnchecked: variableIndex + TempFrameStart ofObject: localHomeContext withValue: self internalStackTop].
	variableType = 2
		ifTrue: [self error: 'illegal store'].
	variableType = 3
		ifTrue: [association _ self literal: variableIndex.
			^ self storePointer: ValueIndex ofObject: association withValue: self internalStackTop]