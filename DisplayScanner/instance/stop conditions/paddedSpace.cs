paddedSpace
	"Each space is a stop condition when the alignment is right justified. 
	Padding must be added to the base width of the space according to 
	which space in the line this space is and according to the amount of 
	space that remained at the end of the line when it was composed."
	| oldX |
	spaceCount _ spaceCount + 1.
	oldX _ destX.
	destX _ destX + spaceWidth + (line justifiedPadFor: spaceCount).
	fillBlt == nil ifFalse:
		[fillBlt destX: oldX destY: destY width: destX - oldX height: height; copyBits].
	lastIndex _ lastIndex + 1.
	^ false