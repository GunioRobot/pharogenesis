tearDown

	| res |
	res := Smalltalk at: #ObjectWithInitializeSubclass ifAbsent: [nil]. 
	res isNil 
		ifFalse: [Smalltalk removeClassNamed: #ObjectWithInitializeSubclass]