printPrimitiveOn: aStream
	"Print the primitive on aStream"
	| primIndex primDecl |
	primIndex _ primitive.
	primIndex = 0 ifTrue:[^self].
	primIndex = 120 "External call spec"
		ifTrue:[^aStream print: encoder literals first].
	aStream nextPutAll: '<primitive: '.
	primIndex = 117 ifTrue:[
		primDecl _ encoder literals at: 1.
		aStream 
			nextPut: $';
			nextPutAll: (primDecl at: 2);
			nextPut:$'.
		(primDecl at: 1) notNil ifTrue:[
			aStream 
				nextPutAll:' module:';
				nextPut:$';
				nextPutAll: (primDecl at: 1);
				nextPut:$'.
		].
	] ifFalse:[aStream print: primIndex].
	aStream nextPut: $>.