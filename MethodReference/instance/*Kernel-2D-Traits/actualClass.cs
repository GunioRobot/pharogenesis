actualClass

	| actualClass traitName|
	('*classTrait' match: classSymbol)
		ifTrue: [ traitName := classSymbol copyUpTo: Character space.
				^ Smalltalk at: traitName asSymbol ifAbsent: [nil]].
	actualClass := Smalltalk at: classSymbol ifAbsent: [^nil].
	classIsMeta ifTrue: [^actualClass classSide].
	^actualClass