frameAndFillRectangle: r fillColor: fillColor borderWidth: borderWidth topLeftColor: topLeftColor bottomRightColor: bottomRightColor
	| rect |
	"First use quick code for fill and top, left borders"
	self frameAndFillRectangle: r
		fillColor: fillColor
		borderWidth: borderWidth
		borderColor: topLeftColor.

	"Now use slow code for bevelled bottom, right borders"
	borderWidth isInteger
		ifTrue: [port width: borderWidth; height: borderWidth]
		ifFalse: [port width: borderWidth x; height: borderWidth y].
	rect _ r translateBy: origin.
	bottomRightColor isTransparent ifFalse: [
		port fillColor: (self drawColor: bottomRightColor);
			frameRectRight: rect;
			frameRectBottom: rect].
