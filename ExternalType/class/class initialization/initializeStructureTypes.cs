initializeStructureTypes
	"ExternalType initialize"
	| referentClass pointerType |
	self cleanupUnusedTypes.
	StructTypes keysAndValuesDo:[:referentName :type|
		referentClass _ (Smalltalk at: referentName ifAbsent:[nil]).
		(referentClass isBehavior and:[
			referentClass includesBehavior: ExternalStructure])
				ifFalse:[referentClass _ nil].
		type compiledSpec: 
			(WordArray with: self structureSpec).
		type newReferentClass: referentClass.
		pointerType _ type asPointerType.
		pointerType compiledSpec: 
			(WordArray with: (self pointerSpec bitOr: self structureSpec)).
		pointerType newReferentClass: referentClass.
	].