pickAt: aPoint extent: extentPoint
	"Initialize the receiver for picking at the given point using the given extent."
	pickMatrix _ self pickingMatrixAt: aPoint extent: extentPoint.