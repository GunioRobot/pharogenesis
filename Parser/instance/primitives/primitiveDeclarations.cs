primitiveDeclarations
	| prim |
	(self matchToken: 'primitive:') ifTrue:
		[prim _ here.
		(self match: #number) ifFalse: [^self expected: 'Integer']].
	^ prim