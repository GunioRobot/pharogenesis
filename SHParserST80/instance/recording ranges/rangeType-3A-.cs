rangeType: aSymbol 
	^self 
		rangeType: aSymbol
		start: currentTokenSourcePosition
		end: currentTokenSourcePosition + currentToken size - 1