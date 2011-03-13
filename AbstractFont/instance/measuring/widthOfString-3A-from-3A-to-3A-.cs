widthOfString: aString from: startIndex to: stopIndex 
	"Measure the length of the given string between start and stop index"
	| character resultX |
	resultX := 0.
	startIndex 
		to: stopIndex
		do: 
			[ :i | 
			character := aString at: i.
			resultX := resultX + (self widthOf: character) ].
	^ resultX