primitive: anIntegerOrString
	"Create indexed primitive."
	
	<primitive>
	^ anIntegerOrString isInteger
		ifTrue: [ anIntegerOrString ]
		ifFalse: [ 
			anIntegerOrString isString
				ifTrue: [ self primitive: anIntegerOrString module: nil ]
				ifFalse: [ self expected: 'Indexed primitive' ] ]