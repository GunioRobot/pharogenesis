valueWithPossibleArgs: anArray 

	| n |
	(n _ self numArgs) = 0 ifTrue: [^ self value].
	n = anArray size ifTrue: [^ self valueWithArguments: anArray].
	^ self valueWithArguments: (n > anArray size
		ifTrue: [anArray, (Array new: n - anArray size)]
		ifFalse: [anArray copyFrom: 1 to: n])