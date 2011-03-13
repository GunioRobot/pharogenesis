primitive
	| n |
	(self matchToken: #<) ifFalse: [^ 0].
	n _ self primitiveDeclarations.
	(self matchToken: #>) ifFalse: [^ self expected: '>'].
	^ n