cursorPageDown: characterStream 

	self closeTypeIn: characterStream.
	self 
		moveCursor: [:position |
			self
				sameColumn: position
				newLine:[:lineNo | lineNo + self pageHeight]
				forward: true]
		forward: true
		specialBlock:[:dummy | dummy].
	^true