outEventNamed: aString
	| spec outAttr |
	spec _ self nodeSpec.
	outAttr _ spec attributeNamed: aString.
	outAttr == nil ifFalse:[
		(outAttr attrClass = 'exposedField' or:[outAttr attrClass = 'eventOut'])
			ifFalse:[outAttr _ nil]].
	(outAttr == nil and:[aString endsWith:'_changed']) ifTrue:[
		outAttr _ spec attributeNamed: (aString copyFrom: 1 to: aString size - 8)].
	outAttr == nil ifFalse:[
		(outAttr attrClass = 'exposedField' or:[outAttr attrClass = 'eventOut'])
			ifFalse:[outAttr _ nil]].
	^outAttr