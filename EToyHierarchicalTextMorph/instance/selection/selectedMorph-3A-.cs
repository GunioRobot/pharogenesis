selectedMorph: aMorph

	selectedMorph == aMorph ifTrue: [^self].
	self unhighlightSelection.
	selectedMorph _ aMorph.
	self highlightSelection