ifEmpty: emptyBlock ifNotEmpty: notEmptyBlock
	"Evaluate emptyBlock if I'm empty, notEmptyBlock otherwise"
	" If the notEmptyBlock has an argument, eval with the receiver as its argument"
	"copied from Collection of course"

	^ self isEmpty ifTrue: emptyBlock ifFalse: [notEmptyBlock valueWithPossibleArgument: self]