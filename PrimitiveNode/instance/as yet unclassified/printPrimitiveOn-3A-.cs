printPrimitiveOn: aStream 
	"Print the primitive on aStream"

	| primIndex primDecl |
	primIndex _ primitiveNum.
	primIndex = 0 ifTrue: [^ self].
	primIndex = 120 ifTrue: [
		"External call spec"
		^ aStream print: spec].
	aStream nextPutAll: '<primitive: '.
	primIndex = 117 ifTrue: [
		primDecl _ spec.
		aStream nextPut: $';
			nextPutAll: (primDecl at: 2);
			nextPut: $'.
		(primDecl at: 1) ifNotNil: [
			aStream nextPutAll: ' module: ';
				nextPut: $';
				nextPutAll: (primDecl at: 1);
				nextPut: $'].
	] ifFalse: [aStream print: primIndex].
	aStream nextPut: $>.
	(primIndex ~= 117 and: [primIndex ~= 120]) ifTrue: [
		Smalltalk at: #Interpreter ifPresent: [:cls |
			aStream nextPutAll: ' "', 
				((cls classPool at: #PrimitiveTable) at: primIndex + 1) , '" '
		].
	].
