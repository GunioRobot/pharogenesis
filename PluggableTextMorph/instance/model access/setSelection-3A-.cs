setSelection: sel
	selectionInterval := sel.
	textMorph editor selectFrom: sel first to: sel last.
	self scrollSelectionIntoView ifFalse: [scroller changed].