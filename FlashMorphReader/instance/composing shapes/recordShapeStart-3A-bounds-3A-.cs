recordShapeStart: shapeId bounds: bounds
	location _ 0@0.
	self logShapes ifFalse:[log _ nil].
	self beginShape.