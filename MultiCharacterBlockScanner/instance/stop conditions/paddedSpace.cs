paddedSpace
	"When the line is justified, the spaces will not be the same as the font's 
	space character. A padding of extra space must be considered in trying 
	to find which character the cursor is pointing at. Answer whether the 
	scanning has crossed the cursor."

	| pad |
	pad _ 0.
	spaceCount _ spaceCount + 1.
	pad _ line justifiedPadFor: spaceCount.
	lastSpaceOrTabExtent _ lastCharacterExtent copy.
	self lastSpaceOrTabExtentSetX:  spaceWidth + pad.
	(destX + lastSpaceOrTabExtent x)  >= characterPoint x
		ifTrue: [lastCharacterExtent _ lastSpaceOrTabExtent copy.
				^self crossedX].
	lastIndex _ lastIndex + 1.
	destX _ destX + lastSpaceOrTabExtent x.
	^ false
