cursorUp: characterStream 

"Private - Move cursor from position in current line to same position in
prior line. If prior line too short, put at end"

	self closeTypeIn: characterStream.
	self
		moveCursor: [:position | self
				sameColumn: position
				newLine:[:line | line - 1]
				forward: false]
		forward: false
		specialBlock:[:dummy | dummy].
	^true