tearDown
	| behaviorName |
	TraitsResource resetIfDirty.
	self createdClassesAndTraits do: 
			[:aClassOrTrait | 
			RequiredSelectors current clearOut: aClassOrTrait.
			behaviorName := aClassOrTrait name.
			Smalltalk at: behaviorName
				ifPresent: [:classOrTrait | classOrTrait removeFromSystem].
			ChangeSet current removeClassChanges: behaviorName].
	createdClassesAndTraits := nil