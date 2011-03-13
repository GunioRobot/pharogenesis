frameAndFillRectangle: r fillColor: fillColor borderWidth: borderWidth topLeftColor: topLeftColor bottomRightColor: bottomRightColor 
 	self setLinewidth:borderWidth; 
	 	rect:r;
		fill:fillColor andStroke:topLeftColor.
	"Now draw bottom right border.
	Note: Must inset this manually!"
	self comment:'draw inset border'.
	self setLinewidth:0.
	0 to: borderWidth-1 do:[ :offset |
		target comment:'drawing inset: ' with:offset.
		EPSCanvas bobsPostScriptHacks ifTrue: [target newpath].
		self moveto:r topRight + ( offset negated @ offset ); 
			lineto:r bottomRight + ( offset negated @ offset negated );
			lineto:r bottomLeft + ( offset @ offset negated ).
		self stroke:bottomRightColor
	]
