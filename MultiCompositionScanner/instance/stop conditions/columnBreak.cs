columnBreak

	"Answer true. Set up values for the text line interval currently being 
	composed."

	line stop: lastIndex.
	presentationLine stop: lastIndex - numOfComposition.
	spaceX := destX.
	line paddingWidth: rightMargin - spaceX.
	presentationLine paddingWidth: rightMargin - spaceX.
	^true