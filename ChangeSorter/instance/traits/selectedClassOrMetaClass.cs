selectedClassOrMetaClass
	"Careful, the class may have been removed!"

	| cName tName className |
	currentClassName ifNil: [^ nil].
	className := (self withoutItemAnnotation: currentClassName) .
	(className endsWith: ' class')
		ifTrue: [cName _ (className copyFrom: 1 to: className size-6) asSymbol.
				^ (Smalltalk at: cName ifAbsent: [^nil]) class].
	(currentClassName endsWith: ' classTrait')
		ifTrue: [tName _ (className copyFrom: 1 to: className size-11) asSymbol.
				^ (Smalltalk at: tName ifAbsent: [^nil]) classTrait].
	cName _ className asSymbol.
	^ Smalltalk at: cName ifAbsent: [nil]