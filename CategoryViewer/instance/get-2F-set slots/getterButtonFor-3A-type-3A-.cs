getterButtonFor: partName type: partType

	| m |
	m _ TileMorph new setOperator: partName.
	m typeColor: (ScriptingSystem colorForType: partType).
	m on: #mouseDown send: #makeGetter:from:forPart:
		to: self
		withValue: (Array with: partName with: partType).
	^ m