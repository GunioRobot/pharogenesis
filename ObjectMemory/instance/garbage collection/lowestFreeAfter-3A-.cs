lowestFreeAfter: chunk
	"Return the first free block after the given chunk in memory."

	| oop oopHeader oopHeaderType oopSize |
	self inline: false.
	oop _ self oopFromChunk: chunk.
	[oop < endOfMemory] whileTrue: [
		oopHeader _ self baseHeader: oop.
		oopHeaderType _ oopHeader bitAnd: TypeMask.
		(oopHeaderType = HeaderTypeFree)
			ifTrue: [ ^ oop ]
			ifFalse: [
				oopHeaderType = HeaderTypeSizeAndClass
					ifTrue: [ oopSize _ (self sizeHeader: oop) bitAnd: AllButTypeMask ]
					ifFalse: [ oopSize _ oopHeader bitAnd: SizeMask ].
			].
		oop _ self oopFromChunk: (oop + oopSize).
	].
	self error: 'expected to find at least one free object'.
