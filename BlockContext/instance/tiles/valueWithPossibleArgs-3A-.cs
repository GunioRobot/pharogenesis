valueWithPossibleArgs: anArray 

	self numArgs = 0 ifTrue: [^self value].
	self numArgs = anArray size ifTrue: [^self valueWithArguments: anArray].
	self numArgs > anArray size ifTrue: [
		^self valueWithArguments: anArray,
				(Array new: (self numArgs - anArray size))
	].
	^self valueWithArguments: (anArray copyFrom: 1 to: self numArgs)

