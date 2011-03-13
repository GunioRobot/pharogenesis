ifNotEmptyDo: aBlock
	"Evaluate the given block with the receiver as its argument."
	"copied from Collection"
	^self isEmpty ifFalse: [aBlock value: self].
