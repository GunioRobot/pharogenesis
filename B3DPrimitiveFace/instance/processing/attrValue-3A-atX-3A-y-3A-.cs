attrValue: attr atX: xValue y: yValue
	"Return the value of the attribute at position xValue@yValue"
	^attr valueAtX: (xValue - v0 rasterPosX) y: (yValue - v0 rasterPosY).