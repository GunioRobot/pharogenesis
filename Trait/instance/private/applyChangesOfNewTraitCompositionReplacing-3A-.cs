applyChangesOfNewTraitCompositionReplacing: oldComposition
	"Duplicated on Class"
	
	| changedSelectors |
	changedSelectors _ super applyChangesOfNewTraitCompositionReplacing: oldComposition.
	self classSide
		noteNewBaseTraitCompositionApplied: self traitComposition.
	^ changedSelectors