selectedClassOrMetaClass
	"Careful, the class may have been removed!"

	| cName |
	currentClassName ifNil: [^ nil].
	(currentClassName endsWith: ' class')
		ifTrue: [cName _ (currentClassName copyFrom: 1 to: currentClassName size-6) asSymbol.
				^ (Smalltalk at: cName ifAbsent: [^nil]) class]
		ifFalse: [cName _ currentClassName asSymbol.
				^ Smalltalk at: cName ifAbsent: [nil]]