hasReverseCellsString
	self reverseTableCells
		ifTrue:[^'<on>reverse table cells']
		ifFalse:[^'<off>reverse table cells']