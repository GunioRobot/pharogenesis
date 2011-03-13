frameAndFillRectangle: r fillColor: fillColor borderWidth: borderWidth borderColor: borderColor 

	"since postscript strokes on the line and squeak strokes inside, we need to adjust inwards"
	self 
		setLinewidth: borderWidth; 
	 	rect: (r insetBy: borderWidth / 2);
		fill: fillColor andStroke: borderColor.
