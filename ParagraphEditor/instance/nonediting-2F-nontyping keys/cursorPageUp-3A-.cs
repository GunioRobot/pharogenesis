cursorPageUp: characterStream 

	self closeTypeIn: characterStream.
	self 
		moveCursor: [:position |
			self
				sameColumn: position
				newLine:[:lineNo | lineNo - self pageHeight]
				forward: false]
		forward: false
		specialBlock:[:dummy | dummy].
	^true