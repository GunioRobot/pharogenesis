in: aBlock
	"Evaluate the given block with the receiver as its argument."

	(aBlock isKindOf: BlockContext) ifFalse: [self error: 'expecting a block'].
	^ aBlock value: self
