doShape: node
	| attr shape |
	attributes at: #currentTexture put: nil.
	attributes at: #currentMaterial put: nil.
	attributes at: #currentShape put: nil.
	(attr _ node attributeValueNamed: 'appearance') notNil
		ifTrue:[attr doWith: self].
	(attr _ node attributeValueNamed: 'geometry') notNil
		ifTrue:[attr doWith: self].
	shape _ attributes at: #currentShape.
	shape == nil ifFalse:[
		shape setMaterial: (attributes at: #currentMaterial ifAbsent:[nil]).
		shape setTexturePointer: (attributes at: #currentTexture ifAbsent:[nil])].