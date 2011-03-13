extent: extent colors: anArray
	"A grid of Colors that can be used to fill a Form.  Initialized from an Array of Colors (x across first row, then second row).  Actual bits are recomputed for the display depth (and cached).  Width, that is (extent x), is limited to 32/depth.  If shown at a depth that is too wide, right hand side colors will not show.  6/20/96 tk"

	^ self new setExtent: extent colors: anArray

"
((Form extent: 50@50 depth: 8) fillColor:
(Pattern extent: 2@2 colors: (Array
	with: Color green with: Color white
	with: Color white with: Color green))) display
"