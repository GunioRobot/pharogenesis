dispatchAsMenuActionTo: anObject with: argument
	^self numArgs = 0
		ifTrue: [self value]
		ifFalse: [self numArgs = 1
					ifTrue: [self value: anObject]
					ifFalse: [self value: anObject value: argument]]