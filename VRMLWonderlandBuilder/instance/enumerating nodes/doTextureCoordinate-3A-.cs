doTextureCoordinate: node

	| attr points |
	(attr _ node attributeValueNamed: 'point') notNil
		ifTrue:[points _ self mfVec2fFrom: attr].
	points == nil
		ifTrue:[attributes removeKey: #currentTexCoords]
		ifFalse:[attributes at: #currentTexCoords put: points].