widthOfString: aString from: firstIndex to: lastIndex
	| resultX |
	resultX _ 0.
	firstIndex to: lastIndex do:[:i | 
		resultX _ resultX + (self widthOf: (aString at: i))].
	^ resultX.
