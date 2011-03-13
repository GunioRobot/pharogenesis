initializeAsAuthoringPrototypeOfType: typeSymbol
	dataType _ typeSymbol.
 	typeSymbol == #string
		ifTrue:
			[self useStringFormat]
		ifFalse:
			[self useDefaultFormat].
	status _ #field.
	lastValue _ contents _ 'Data'.
	self setNameTo: 'field'