findFirstInMultiString: aString  inSet: inclusionMap  startingAt: start
	| i stringSize ascii more |
	
	self var: #aString declareC: 'unsigned int *aString'.
	self var: #inclusionMap declareC: 'char *inclusionMap'.

	inclusionMap size ~= 256 ifTrue: [^ 0].

	stringSize _ aString size.
	more _ true.
	i _ start - 1.
	[more and: [i + 1 <= stringSize]] whileTrue: [
		i _ i + 1.
		ascii _ (aString at: i) asciiValue.
		more _ ascii < 256 ifTrue: [(inclusionMap at: ascii + 1) = 0] ifFalse: [true].
	].

	i + 1 > stringSize ifTrue: [^ 0].
	^ i.
