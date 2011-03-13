widthOfString: aString from: startIndex to: stopIndex
	"Measure the length of the given string between start and stop index"

	| resultX |
	resultX _ 0.
	startIndex to: stopIndex do:[:i | 
		resultX _ resultX + (self widthOf: (aString at: i))].
	^ resultX.
