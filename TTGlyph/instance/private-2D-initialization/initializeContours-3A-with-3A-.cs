initializeContours: numContours with: endPoints
	"Initialize the contours for creation of the glyph."
	| startPt pts endPt |
	contours _ Array new: numContours.
	startPt _ -1.
	1 to: numContours do:[:i|
		endPt _ endPoints at: i.
		pts _ Array new: endPt - startPt.
		1 to: pts size do:[:j| pts at: j put: TTPoint new].
		contours at: i put: (TTContourConstruction on: pts).
		startPt _ endPt].