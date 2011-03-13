bitPatternForDepth: newDepth
	"The raw call on BitBlt needs a Bitmap to represent this pattern of colors.  I already am Bitmap like.  See if my cached bits are at the right depth already.  If not, recompute.  Interpret me as an array of (32/depth) Color pixelValues.  BitBlt aligns the first element of this array with the top scanline of the destinationForm, the second with the second, and so on, cycling through the color array as necessary.  See BitBlt class comment.  6/20/96 tk"

	newDepth = depth ifTrue: [^ self].	"cache is good"
	self depth: newDepth.
	^ self