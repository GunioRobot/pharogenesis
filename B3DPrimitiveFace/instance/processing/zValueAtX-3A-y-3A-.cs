zValueAtX: xValue y: yValue
	"Return the z value of the receiver at position xValue@yValue"
	^v0 rasterPosZ +
		(yValue - v0 rasterPosY * dzdy) +
		(xValue - v0 rasterPosX * dzdx)