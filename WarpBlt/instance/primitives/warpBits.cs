warpBits
	"Move those pixels!"

	self warpBitsSmoothing: cellSize
		sourceMap: (Color colorMapIfNeededFrom: sourceForm depth to: 32).
