doesOperatorWantArrows: aSymbol
	^ aSymbol isInfix or: [#(isDivisibleBy:) includes: aSymbol]