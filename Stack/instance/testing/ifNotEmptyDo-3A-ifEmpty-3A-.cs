ifNotEmptyDo: notEmptyBlock ifEmpty: emptyBlock
	"Evaluate emptyBlock if I'm empty, notEmptyBlock otherwise
	Evaluate the notEmptyBlock with the receiver as its argument"
	"copied from Collection"

	^ self isEmpty ifFalse: [notEmptyBlock value: self] ifTrue: emptyBlock