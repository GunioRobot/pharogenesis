doAppearance: node
	| attr |
	(attr _ node attributeValueNamed: 'material') notNil
		ifTrue:[attr doWith: self].
	(attr _ node attributeValueNamed: 'texture') notNil
		ifTrue:[attr doWith: self].
	(attr _ node attributeValueNamed: 'textureTransform') notNil
		ifTrue:[attr doWith: self].
