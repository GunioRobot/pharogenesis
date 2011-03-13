paddedSpace
	"Each space is a stop condition when the alignment is right justified. 
	Padding must be added to the base width of the space according to 
	which space in the line this space is and according to the amount of 
	space that remained at the end of the line when it was composed."

	spaceCount _ spaceCount + 1.
	lastIndex _ lastIndex + 1.
	destX _ destX + spaceWidth + (line justifiedPadFor: spaceCount).
	^false