doCoordinate: node
	| attr points |
	(attr _ node attributeValueNamed: 'point') notNil
		ifTrue:[points _ self mfVec3fFrom: attr].
	points == nil
		ifTrue:[attributes removeKey: #currentPoints]
		ifFalse:[attributes at: #currentPoints put: points].