warpBitsSimulated
	"Simulate WarpBlt"
	self warpBitsSimulated: cellSize
		sourceMap: (sourceForm colormapIfNeededForDepth: 32).
