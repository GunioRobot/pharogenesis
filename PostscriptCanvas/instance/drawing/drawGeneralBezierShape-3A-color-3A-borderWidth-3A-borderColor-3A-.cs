drawGeneralBezierShape: shapeArray
					color: color 
					borderWidth: borderWidth 
					borderColor: borderColor
	shapeArray do:[ :shape | self outlineQuardraticBezierShape:shape ].
	self setLinewidth:borderWidth;
		fill:color andStroke:borderColor.

