addModelVariable
	| accessors |
	accessors _ component model addVariableNamed: component knownName , pinSpec pinName.
	pinSpec modelReadSelector: accessors first modelWriteSelector: accessors second.
	component initFromPinSpecs.
	self connectedPins do: [:connectee | connectee shareVariableOf: self]