bindingOf: aString
	bindings isNil
		ifTrue: [bindings _ Dictionary new].
	(bindings includesKey: aString)
		ifFalse: [bindings at: aString put: nil].
	^bindings associationAt: aString