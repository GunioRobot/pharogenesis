applyChangesOfNewTraitCompositionReplacing: oldComposition
	"See Trait>>applyChangesOfNewTraitCompositionReplacing:"
	| changedSelectors |
	changedSelectors _ super applyChangesOfNewTraitCompositionReplacing: oldComposition.
	self classSide
		noteNewBaseTraitCompositionApplied: self traitComposition.
	^ changedSelectors