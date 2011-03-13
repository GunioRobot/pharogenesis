setArray2D: anArray2D
	"A grid of Colors that can be used to fill a Form.  Actual bits are recomputed for the display depth (and cached).  Width is limited to (32/depth).  If shown at a depth that is too wide, right hand side colors will not show.  6/20/96 tk"

	colorArray2D == nil ifFalse: [
		^ self error: 'Can''t change a Pattern.  Please make a new one'].
	"anArray2D width > 32 ifTrue: [
		self error: 'Too wide. Some colors won''t show']."
		"OK to use as a route from a big Array of Colors to a Form?" 
	colorArray2D _ anArray2D.
	depth == nil ifFalse: [self cacheBits].