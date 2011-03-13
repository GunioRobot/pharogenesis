setExtent: extent colors: anArray
	"A grid of Colors that can be used to fill a Form.  Initialized from an Array of Colors (x across first row, then second row).  Actual bits are recomputed for the display depth (and cached).  Width, that is (extent x), is limited to 32/depth.  If shown at a depth that is too wide, right hand side colors will not show.  6/20/96 tk"

	colorArray2D == nil ifFalse: [
		^ self error: 'Can''t change a Pattern.  Please make a new one'].
	"extent x > 32 ifTrue: [
		self error: 'Too wide. Some colors won''t show']."
		"Use as a route from a big array of Colors to a Form?" 
	colorArray2D _ Array2D new extent: extent fromArray: anArray.
	depth == nil ifFalse: [self cacheBits].