space
	"Record left x and character index of the space character just encounted. 
	Used for wrap-around. Answer whether the character has crossed the 
	right edge of the composition rectangle of the paragraph."

	spaceX _ destX.
	destX _ spaceX + spaceWidth.
	spaceIndex _ lastIndex.
	lineHeightAtSpace _ lineHeight.
	baselineAtSpace _ baseline.
	lastIndex _ lastIndex + 1.
	spaceCount _ spaceCount + 1.
	destX > rightMargin ifTrue: 	[^self crossedX].
	^false
