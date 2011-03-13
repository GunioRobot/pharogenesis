applyChangesOfNewTraitCompositionReplacing: oldComposition
	| changedSelectors |
	changedSelectors _ super applyChangesOfNewTraitCompositionReplacing: oldComposition.
	self noteRecategorizedSelectors: changedSelectors oldComposition: oldComposition.
	^ changedSelectors.