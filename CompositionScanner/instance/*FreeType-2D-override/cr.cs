cr
	"Answer true. Set up values for the text line interval currently being 
	composed."

	pendingKernX := 0.
	line stop: lastIndex.
	spaceX := destX.
	line paddingWidth: rightMargin - spaceX.
	^true