doNormal: node
	| attr points |
	(attr _ node attributeValueNamed: 'vector') notNil
		ifTrue:[points _ self mfVec3fFrom: attr].
	points == nil
		ifTrue:[attributes removeKey: #currentNormals]
		ifFalse:[attributes at: #currentNormals put: points].