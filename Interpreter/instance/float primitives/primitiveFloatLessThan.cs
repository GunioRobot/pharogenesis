primitiveFloatLessThan
	| aBool |
	aBool _ self primitiveFloatLess: (self stackValue: 1) thanArg: self stackTop.
	successFlag ifTrue: [self pop: 2. self pushBool: aBool].
