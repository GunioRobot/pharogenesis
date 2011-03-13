hasClipLayoutCellsString
	self clipLayoutCells
		ifTrue:[^'<on>clip to cell size']
		ifFalse:[^'<off>clip to cell size']