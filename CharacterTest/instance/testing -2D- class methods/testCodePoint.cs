testCodePoint

	self assert: (Character codePoint: $a codePoint) = $a.
	self assert: (Character codePoint: 97) codePoint = 97.