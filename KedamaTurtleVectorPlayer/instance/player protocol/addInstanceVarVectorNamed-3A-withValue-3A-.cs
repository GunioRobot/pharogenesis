addInstanceVarVectorNamed: aName withValue: aValue

	| newArray |
	newArray _ KedamaFloatArray new: self size.
	arrays _ arrays, (Array with: newArray).
	newArray atAllPut: aValue.
	info at: aName asSymbol put: arrays size.
	types at: arrays size put: #Number.
