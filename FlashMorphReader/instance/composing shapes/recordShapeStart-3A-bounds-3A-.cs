recordShapeStart: shapeId bounds: bounds
	location := 0@0.
	self logShapes ifFalse:[log := nil].
	self beginShape.