primDisplayString: aString from: startIndex to: stopIndex map: glyphMap xTable: xTable kern: kernDelta 
	| ascii |
	<primitive:'primitiveDisplayString' module:'BitBltPlugin'>
	startIndex 
		to: stopIndex
		do: 
			[ :charIndex | 
			ascii := (aString at: charIndex) asciiValue.
			sourceX := xTable at: ascii + 1.
			width := (xTable at: ascii + 2) - sourceX.
			self copyBits.
			destX := destX + width + kernDelta ]