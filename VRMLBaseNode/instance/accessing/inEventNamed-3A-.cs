inEventNamed: aString
	| spec inAttr |
	spec _ self nodeSpec.
	inAttr _ spec attributeNamed: aString.
	inAttr == nil ifFalse:[
		(inAttr attrClass = 'exposedField' or:[inAttr attrClass = 'eventIn'])
			ifFalse:[inAttr _ nil]].
	(inAttr == nil and:[aString beginsWith:'set_']) ifTrue:[
		inAttr _ spec attributeNamed: (aString copyFrom: 5 to: aString size)].
	inAttr == nil ifFalse:[
		(inAttr attrClass = 'exposedField' or:[inAttr attrClass = 'eventIn'])
			ifFalse:[inAttr _ nil]].
	^inAttr