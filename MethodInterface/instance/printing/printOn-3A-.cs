printOn: aStream
	"print the receiver on a stream.  Overridden to provide details about wording, selector, result type, and companion setter."

	super printOn: aStream.
	aStream nextPutAll: ' - wording: ';
		print: self wording;
		nextPutAll: ' selector: ';
		print: selector.
	self argumentVariables size > 0 ifTrue:
		[aStream nextPutAll: ' Arguments: '.
		argumentVariables doWithIndex:
			[:aVariable :anIndex | 
				aStream nextPutAll: 'argument #', anIndex printString, ' name = ', aVariable variableName asString, ', type = ', aVariable variableType]].
	resultSpecification ifNotNil:
		[aStream nextPutAll: ' result type = ', resultSpecification resultType asString.
		resultSpecification companionSetterSelector ifNotNil:
			[aStream nextPutAll: ' setter = ', resultSpecification companionSetterSelector asString]]
	