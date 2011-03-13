array2D: anArray2D
	"Create a new pattern.  A grid of Colors that can be used to fill a Form.  Actual bits recomputed for the display depth (and cached).  Width, that is (extent x), is limited to 32/depth.  If shown at a depth that is too wide, right hand side colors will not show.  6/20/96 tk"

	^ self new setArray2D: anArray2D