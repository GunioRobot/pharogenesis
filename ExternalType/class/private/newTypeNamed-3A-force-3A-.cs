newTypeNamed: aString force: aBool
	| sym type referentClass pointerType |
	sym _ aString asSymbol.
	type _ StructTypes at: aString ifAbsent:[nil].
	type == nil ifFalse:[^type].
	referentClass _ Smalltalk at: sym ifAbsent:[nil].
	(referentClass isBehavior and:[referentClass includesBehavior: ExternalStructure])
		ifFalse:[referentClass _ nil].
	"If we don't have a referent class and are not forced to create a type get out"
	(referentClass == nil and:[aBool not]) ifTrue:[^nil].
	type _ self basicNew compiledSpec: 
		(WordArray with: self structureSpec).
	pointerType _ self basicNew compiledSpec: 
		(WordArray with: self pointerSpec).
	type setReferencedType: pointerType.
	pointerType setReferencedType: type.
	type newReferentClass: referentClass.
	pointerType newReferentClass: referentClass.
	StructTypes at: sym put: type.
	^type