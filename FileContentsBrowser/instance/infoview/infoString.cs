infoString
	^infoString isNil
		ifTrue:[infoString := StringHolder new]
		ifFalse:[infoString]