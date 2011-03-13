addInstanceVarNamed: aName withValue: aValue

	| newArray |
	(aValue isKindOf: Number) ifTrue: [
		newArray _ KedamaFloatArray new: self size.
	].
	(aValue isKindOf: Color) ifTrue: [
		newArray _ WordArray new: self size.
	].
	(aValue isKindOf: Player) ifTrue: [
		newArray _ Array new: self size.
	].

	arrays _ arrays, newArray.
	info at: aName asSymbol put: arrays size.
