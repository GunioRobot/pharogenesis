rangeOf: attribute startingAt: index forStyle: aTextStyle
"aTextStyle is not really needed, it is kept for compatibility with an earlier method version "
	self deprecated: 'Use Text>>rangeOf:startingAt: instead.'.
	^self rangeOf: attribute startingAt: index