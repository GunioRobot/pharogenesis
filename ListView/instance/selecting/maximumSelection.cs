maximumSelection
	"Answer which selection is the last possible one."
	^ list numberOfLines
		- (topDelimiter == nil ifTrue: [0] ifFalse: [1])
		- (bottomDelimiter == nil ifTrue: [0] ifFalse: [1])