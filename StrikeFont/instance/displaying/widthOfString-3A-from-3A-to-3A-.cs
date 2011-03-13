widthOfString: aString from: firstIndex to: lastIndex 
	| resultX |
	resultX := 0.
	firstIndex 
		to: lastIndex
		do: [ :i | resultX := resultX + (self widthOf: (aString at: i)) ].
	^ resultX