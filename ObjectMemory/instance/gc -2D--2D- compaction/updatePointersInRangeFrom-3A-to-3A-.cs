updatePointersInRangeFrom: memStart to: memEnd 
	"update pointers in the given memory range"
	| oop |
	self inline: false.
	oop _ self oopFromChunk: memStart.
	[oop < memEnd]
		whileTrue: [(self isFreeObject: oop)
				ifFalse: [self remapFieldsAndClassOf: oop].
			oop _ self objectAfterWhileForwarding: oop]