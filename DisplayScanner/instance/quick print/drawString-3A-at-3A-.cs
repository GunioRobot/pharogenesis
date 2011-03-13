drawString: aString at: aPoint
	"Draw the given string."

	destX _ aPoint x asInteger.
	destY _ aPoint y asInteger.
	lastIndex _ 1.		"else the prim will fail"
	self primScanCharactersFrom: 1 to: aString size in: aString
		rightX: bitBlt clipX + bitBlt clipWidth + font maxWidth
		stopConditions: stopConditions kern: kern.
	font displayString: aString on: bitBlt from: 1 to: lastIndex at: aPoint kern: kern.