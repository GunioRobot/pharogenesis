after: target ifAbsent: exceptionBlock
	"Answer the element after target.  Answer the result of evaluation
	the exceptionBlock if target is not in the receiver, or if there are 
	no elements after it."

	| index |
	index _ self indexOf: target.
	^ index == 0
		ifTrue: [exceptionBlock value]
		ifFalse: [index = self size 
			ifTrue: [self errorLastObject: target]
			ifFalse: [self at: index + 1]]