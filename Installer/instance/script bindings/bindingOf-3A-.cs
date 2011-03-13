bindingOf: aString 
	
	Bindings isNil ifTrue: [ Bindings := Dictionary new].

	(Bindings includesKey: aString)
		ifFalse: [Bindings at: aString put: nil].

	^ Bindings associationAt: aString.