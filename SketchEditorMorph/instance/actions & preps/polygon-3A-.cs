polygon: evt
	| poly |
	poly _ self valueOfProperty: #polygon.
	poly ifNil:[^self].
	evt cursorPoint > poly bounds origin ifTrue:[
		poly extent: ((evt cursorPoint - poly bounds origin) max: 5@5)].