before: target ifAbsent: exceptionBlock
	"Answer the receiver's element immediately before target. Answer
	the result of evaluating the exceptionBlock if target is not an element
	of the receiver, or if there are no elements before it."

	| index |
	index _ self indexOf: target.
	^ index == 0
		ifTrue: [exceptionBlock value]
		ifFalse: [index == 1 
			ifTrue: [self errorFirstObject: target]
			ifFalse: [self at: index - 1]]