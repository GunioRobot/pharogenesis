tabletScaleFactor
	"Answer a Point that scales tablet coordinates to Display coordinates, where the full extent of the tablet maps to the extent of the entire Display."

	| tabletExtent |
	tabletExtent _ Sensor tabletExtent.
	^ (Display width asFloat / tabletExtent x) @ (Display height asFloat / tabletExtent y)
