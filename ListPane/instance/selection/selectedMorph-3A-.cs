selectedMorph: aMorph
	self unhighlightSelection.
	selectedMorph _ aMorph.
	selection _ aMorph ifNil: [nil] ifNotNil: [aMorph contents].
	self highlightSelection