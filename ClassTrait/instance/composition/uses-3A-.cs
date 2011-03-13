uses: aTraitCompositionOrArray
	| copyOfOldTrait newComposition |
	copyOfOldTrait _ self copy.
	newComposition _ aTraitCompositionOrArray asTraitComposition.
	self assertConsistantCompositionsForNew: newComposition.
	self setTraitComposition: newComposition.
	SystemChangeNotifier uniqueInstance
		traitDefinitionChangedFrom: copyOfOldTrait to: self.