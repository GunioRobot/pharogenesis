start: startInteger stop: stopInteger internalSpaces: spacesInteger paddingWidth: padWidthInteger
	"Answer an instance of me with the arguments as the start, stop points, 
	number of spaces in the line, and width of the padding."

	| newSelf |
	newSelf _ super from: startInteger to: stopInteger by: 1.
	^newSelf internalSpaces: spacesInteger paddingWidth: padWidthInteger