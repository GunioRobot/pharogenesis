applyChangesOfNewTraitCompositionReplacing: oldComposition
	| changedSelectors |
	changedSelectors _ self traitComposition
		changedSelectorsComparedTo: oldComposition.
	changedSelectors isEmpty ifFalse: [
		self noteChangedSelectors: changedSelectors].
	self traitComposition isEmpty ifTrue: [
		self purgeLocalSelectors].
	^changedSelectors