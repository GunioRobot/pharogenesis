warpBits
	"Move those pixels!"

	self warpBitsSmoothing: cellSize
		sourceMap: (sourceForm colormapIfNeededForDepth: 32).
