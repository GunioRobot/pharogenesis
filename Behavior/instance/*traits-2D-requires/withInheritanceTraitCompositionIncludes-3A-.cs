withInheritanceTraitCompositionIncludes: aTrait
	^self withAllSuperclasses anySatisfy: [:c | c traitCompositionIncludes: aTrait]