getSelectedText
	| m interval text |
	m := self getTextMorphWithSelection.
	interval := m selectionInterval.
	text := m text.
	^ text copyFrom: interval first to: interval last
	