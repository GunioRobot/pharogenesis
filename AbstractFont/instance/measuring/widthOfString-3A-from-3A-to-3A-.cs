widthOfString: aString from: startIndex to: stopIndex
	"Measure the length of the given string between start and stop index"
	| character resultX |
	resultX _ 0.
	startIndex to: stopIndex do:[:i | 
		character _ aString at: i.
		resultX _ resultX + (self widthOf: character)].
	^resultX