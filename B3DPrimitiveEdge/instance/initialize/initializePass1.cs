initializePass1
	"Assume: v0 sortsBefore: v1"
	xValue _ v0 windowPosX.
	yValue _ v0 windowPosY.
	zValue _ v0 rasterPosZ.
	xIncrement _ (v1 windowPosX - v0 windowPosX) // nLines.
	zIncrement _ (v1 rasterPosZ - v0 rasterPosZ) / nLines.