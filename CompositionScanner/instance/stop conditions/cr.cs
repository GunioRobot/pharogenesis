cr
	"Answer true. Set up values for the text line interval currently being 
	composed."

	line stop: lastIndex.
	spaceX _ destX.
	line paddingWidth: rightMargin - destX.
	^true