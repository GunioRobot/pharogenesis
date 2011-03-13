setSelection: sel
	selectionInterval _ sel.
	textMorph editor selectFrom: sel first to: sel last.
	self scrollSelectionIntoView