valueAtX: xValue y: yValue
	"Return the value of the attribute at position xValue@yValue"
	^value + (yValue * dvdy) + (xValue * dvdx)